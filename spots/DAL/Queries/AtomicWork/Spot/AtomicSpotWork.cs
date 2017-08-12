using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.DAL.Mongo.Context;
using spots.DAL.Queries.AtomicWork.Group;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Authorisation.Actions;
using spots.Models.Event;
using spots.Models.Spot.Interfaces;
using spots.Models.Spot.ViewModels;

namespace spots.DAL.Queries.AtomicWork.Spot
{
    public class AtomicSpotWork : AtomicWork, IAtomicSpotWork
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISpotUserRepository _spotUserRepository;
        private readonly IGroupRepository _groupRepository;

        public AtomicSpotWork(ISpotUserRepository spotUserRepository, IGroupRepository groupGroupRepository)
        {
            _businessRepository = new BusinessRepository(new MongoContextGeneric<Models.Business.Business>());
            _locationRepository = new LocationRepository(new MongoContextGeneric<Models.Location.Location>());
            _spotRepository = new SpotRepository(new MongoContextGeneric<Models.Spot.Spot>());
            _eventRepository = new EventRepository(new MongoContextGeneric<Models.Event.Event>());
            _spotUserRepository = spotUserRepository;
            _groupRepository = groupGroupRepository;
        }

        public override string Desc => "Atomic spot work.";

        public IEnumerable<string> GetAvailableSpotIdsInCity(string city, BsonDateTime starDateTime, BsonDateTime endDateTime)
        {
            var allSpots = _locationRepository.GetSpotIdsInCity(city).ToList();
            var occupiedSpots = _eventRepository.GetOccupiedSpotIds(city, starDateTime, endDateTime);
            occupiedSpots.ForEach(s => allSpots.Remove(s));

            return allSpots;
        }

       

        public void Add(ISpot spot)
        {
            try
            {
                Lock();

                _spotRepository.Add(spot);
                _locationRepository.AddSpot(spot.Id, spot.LocationId);
            }
            catch (Exception)
            {
                //TODO: Rollback logic
                throw new Exception("Failed to perform atomic action - " + Desc);
            }
            finally
            {
                Unlock();
            }
        }

           

        
    }
}