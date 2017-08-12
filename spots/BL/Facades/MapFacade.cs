using System;
using Castle.Core.Internal;
using spots.BL.Core.Interfaces;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Modules.Map.Models;

namespace spots.BL.Facades
{
    public class MapFacade : IMapFacade
    {
        private readonly IMapCore _core;
        private readonly ISpotUserRepository _userRepository;

        public MapFacade(IMapCore core, ISpotUserRepository userRepository)
        {
            _core = core;
            _userRepository = userRepository;
        }

        public MapLocation GetMapLocationViewModel(string latitude, string longitude)
        {
            return new MapLocation
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }

        public MapDetailsViewModel GetMapDetailsViewModel(MapFilter filter)
        {           
            var startDate = DateTime.Parse(filter.StartDate);
            var endDate = DateTime.Parse(filter.EndDate);
            var city = _core.GetCityFilter(filter.City);

            if (city == null)
            {
                return null;
            }

            var spotIds = _core.GetEventSpots(city, startDate, endDate);
            var addresses = _core.GetAddressesFromSpots(spotIds);
            var geolocations = _core.GetGeoLocations(addresses);

            var centerGeolocation = _core.GetGeoLocation(city);

            return new MapDetailsViewModel
            {
                Geolocations = geolocations,
                CenterPosition = centerGeolocation
            };
        }
    }
}