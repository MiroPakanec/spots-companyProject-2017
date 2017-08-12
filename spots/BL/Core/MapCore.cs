using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.BL.Core.Helpers;
using spots.BL.Core.Interfaces;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Modules.Map.Models;

namespace spots.BL.Core
{
    public class MapCore : IMapCore
    {
        private readonly ISpotUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly ILocationRepository _locationRepository;

        public MapCore(ISpotUserRepository userRepository, IEventRepository eventRepository,
            ISpotRepository spotRepository, ILocationRepository locationRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
            _spotRepository = spotRepository;
            _locationRepository = locationRepository;
        }

        public IEnumerable<ObjectId> GetEventSpots(string city, DateTime startDateTime, DateTime endDateTime)
        {
            return _eventRepository.GetEventSpots(city, startDateTime, endDateTime);
        }

        public IEnumerable<string> GetAddressesFromSpots(IEnumerable<ObjectId> spotIds)
        {
            var addresses = new HashSet<string>();

            foreach (var spotId in spotIds)
            {
                var locationId = _spotRepository.GetWithId(spotId).LocationId;
                var location = _locationRepository.GetWithId(locationId);

                addresses.Add(location.FullAddress);
            }

            //todo: store cardinality of each record (e.g. Jernbanegade 12A : 5)
            return addresses;
        }

        public IEnumerable<MapLocation> GetGeoLocations(IEnumerable<string> addresses)
        {
            return addresses
                    .Select(GoogleAPI.GeolocationRequest)
                    .Select(GoogleAPI.ManageGeolocationResponse)
                    .ToList();
        }

        public MapLocation GetGeoLocation(string address)
        {
            var xdoc = GoogleAPI.GeolocationRequest(address);
            var geolocation = GoogleAPI.ManageGeolocationResponse(xdoc);

            return geolocation;
        }

        public string GetCurentLocation()
        {
            throw new NotImplementedException();
        }

        public string GetCityFilter(string city)
        {
            if (city.IsNullOrEmpty() == false)
            {
                return city;
            }

            var userCity = _userRepository.GetCurrent.City;

            if (userCity.IsNullOrEmpty() == false)
            {
                return userCity;
            }

            return null;
        }
    }
}