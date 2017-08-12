using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using spots.DAL.Mongo.Context;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Event.Interfaces;
using spots.Models.Event.ViewModels;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Services.DateService;
using WebGrease.Css.Extensions;

namespace spots.DAL.Queries.AtomicWork.Event
{
    public class AtomicEventWork : AtomicWork, IAtomicEventWork
    {
        private readonly ISpotUserRepository _userRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly IEventRepository _eventRepository;

        public AtomicEventWork()
        {
            _userRepository = new SpotUserRepository(new MongoContextGeneric<SpotUser>());
            _businessRepository = new BusinessRepository(new MongoContextGeneric<Models.Business.Business>());
            _locationRepository = new LocationRepository(new MongoContextGeneric<Models.Location.Location>());
            _spotRepository = new SpotRepository(new MongoContextGeneric<Models.Spot.Spot>());
            _eventRepository = new EventRepository(new MongoContextGeneric<Models.Event.Event>());
        }

        public override string Desc => "Atomic event work.";

        public IEventDetails GetEventDetails(ObjectId eventId)
        {
            try
            {
                var anEvent = _eventRepository.GetWithId(eventId);
                var invited = new List<SpotUser>();
                anEvent.Invited.ForEach(user => invited.Add(_userRepository.GetWithId(user) as SpotUser));

                var spot = _spotRepository.GetWithId(anEvent.SpotId);
                var location = _locationRepository.GetWithId(spot.LocationId);
                var business = _businessRepository.GetWithId(location.BusinessId);

                return new EventDetailsViewModel
                {
                    Id = anEvent.Id,
                    Title = anEvent.Title,
                    Description = anEvent.Description,
                    StartDatetime = anEvent.StartDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat),
                    EndDatetime = anEvent.EndDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat),
                    Invited = invited,
                    SpotId = spot.Id,
                    SpotName = spot.Name,
                    Location = location.FullAddress,
                    BusinessId = business.Id,
                    BusinessName = business.Name
                };
            }
            catch (Exception)
            {
                throw new Exception("Failed to perform atomic action GetEventDetails - " + Desc);
            }
        }

        public IEventDetails GetEventDetails(string eventId)
        {
            return GetEventDetails(ObjectId.Parse(eventId));
        }

        public IEnumerable<EventDetailsViewModel> SearchEvents(string city, BsonDateTime date, int skip, string orderBy)
        {
            try
            {
                var take = 5;

                var eventDetailList = new List<EventDetailsViewModel>();

                var events = orderBy == "popular"
                    ? _eventRepository.GetByLocationAndTime(city, date).OrderByDescending(e => e.Invited.Count)
                    : _eventRepository.GetByLocationAndTime(city, date).OrderBy(e => e.StartDateTime);

                foreach (var anEvent in events)
                {
                    if (take <= 0) continue;

                    if (skip > 0)
                    {
                        skip--;
                        continue;
                    }

                    var invited = new List<SpotUser>();
                    anEvent.Invited.ForEach(user => invited.Add(_userRepository.GetWithId(user) as SpotUser));

                    var spot = _spotRepository.GetWithId(anEvent.SpotId);
                    var location = _locationRepository.GetWithId(spot.LocationId);
                    var business = _businessRepository.GetWithId(location.BusinessId);

                    eventDetailList.Add(new EventDetailsViewModel
                    {
                        Id = anEvent.Id,
                        Title = anEvent.Title,
                        Description = anEvent.Description,
                        StartDatetime = anEvent.StartDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat),
                        EndDatetime = anEvent.EndDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat),
                        Invited = invited,
                        SpotId = spot.Id,
                        SpotName = spot.Name,
                        Location = location.FullAddress,
                        BusinessId = business.Id,
                        BusinessName = business.Name
                    });

                    take--;
                }

                return eventDetailList;
            }
            catch (Exception)
            {
                throw new Exception("Failed to perform atomic action Add - " + Desc);
            }
        }

        public void Add(IEvent anEvent, IUserEvent userEvent)
        {
            try
            {
                Lock();

                _eventRepository.Add(anEvent);
                _userRepository.AddEventForMany(userEvent, anEvent.Invited);
            }
            catch (Exception)
            {
                //TODO: Rollback logic
                throw new Exception("Failed to perform atomic action Add - " + Desc);
            }
            finally
            {
                Unlock();
            }
        }
    }
}