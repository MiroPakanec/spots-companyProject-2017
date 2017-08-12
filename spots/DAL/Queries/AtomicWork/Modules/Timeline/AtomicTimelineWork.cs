using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.DAL.Mongo.Context;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Modules.Timeline.Interfaces;
using spots.Modules.Timeline.ViewModels;
using spots.Services.DateService;

namespace spots.DAL.Queries.AtomicWork.Modules.Timeline
{
    public class AtomicTimelineWork : AtomicWork, IAtomicTimelineWork
    {
        private readonly ISpotUserRepository _userRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly IEventRepository _eventRepository;

        public AtomicTimelineWork()
        {
            _userRepository = new SpotUserRepository(new MongoContextGeneric<SpotUser>());
            _businessRepository = new BusinessRepository(new MongoContextGeneric<Models.Business.Business>());
            _locationRepository = new LocationRepository(new MongoContextGeneric<Models.Location.Location>());
            _spotRepository = new SpotRepository(new MongoContextGeneric<Models.Spot.Spot>());
            _eventRepository = new EventRepository(new MongoContextGeneric<Models.Event.Event>());
        }

        public override string Desc => "Atomic timeline work.";

        public IEnumerable<ITimelineEvent> GetFutureEvents(int skip, int take)
        {
            var events = new List<ITimelineEvent>();

            //Step 1 - Get {all} users
            var userList = _userRepository.GetAllExceptCurrent;

            //Step 2 - Get all user events        
            return GetFutureEventsSearch(take, skip, 0, 10, userList, events).OrderBy(e => e.EventStart);
        }

        public IEnumerable<ITimelineEvent> GetPastEvents(int skip, int take)
        {
            var events = new List<ITimelineEvent>();

            //Step 1 - Get {all} users
            var userList = _userRepository.GetAllExceptCurrent;

            //Step 2 - Get all user events        
            return GetPastEventsSearch(take, skip, 0, 10, userList, events).OrderByDescending(e => e.EventStart);
        }

        public IEnumerable<ITimelineEvent> GetFutureUserEvents(int skip, int take, string id)
        {
            var events = new List<ITimelineEvent>();

            //Step 1 - Get user obj
            var user = _userRepository.GetWithId(id);
            var userList = new List<ISpotUser> { user };

            //Step 2 - Get all user events
            return GetFutureEventsSearch(take, skip, 0, 10, userList, events).OrderBy(e => e.EventStart);
        }

        public IEnumerable<ITimelineEvent> GetPastUserEvents(int skip, int take, string id)
        {
            var events = new List<ITimelineEvent>();

            //Step 1 - Get user obj
            var user = _userRepository.GetWithId(id);
            var userList = new List<ISpotUser> { user };

            //Step 2 - Get all user events
            return GetPastEventsSearch(take, skip, 0, 10, userList, events).OrderByDescending(e => e.EventStart);
        }

        private List<ITimelineEvent> GetFutureEventsSearch(
            int toTake, int toSkip, int intervalStart, int intervalEnd, IEnumerable<ISpotUser> users, List<ITimelineEvent> events)
        {
            if (toTake <= 0) return events;

            var spotUsers = users as ISpotUser[] ?? users.ToArray();
            foreach (var user in spotUsers)
            {
                var userEvents = user.MyEvents;
                if (userEvents.IsNullOrEmpty()) continue;

                foreach (var userEvent in userEvents)
                {
                    if (toTake <= 0) return events;

                    if (IsDateInFutureInterval(userEvent.StartDateTime, intervalStart, intervalEnd) == false) { continue; }

                    var anEvent = _eventRepository.GetWithId(userEvent.EventId);
                    if (anEvent.Visibility == false) continue;

                    if (toSkip > 0)
                    {
                        toSkip--;
                        continue;
                    }

                    //Step 3 - create timeline event
                    var spot = _spotRepository.GetWithId(anEvent.SpotId);
                    var location = _locationRepository.GetWithId(spot.LocationId);
                    var business = _businessRepository.GetWithId(location.BusinessId);

                    events.Add(new TimelineEventViewModel(user, anEvent, userEvent, spot, location, business));
                    toTake--;
                }
            }

            //Recurtion logic
            if (toTake <= 0) return events;

            if(intervalEnd > 1000) return events;

            //TODO: Adjust increment of end interval
            return GetFutureEventsSearch(toTake, toSkip, intervalEnd, intervalEnd + 12, spotUsers, events);
        }

        private List<ITimelineEvent> GetPastEventsSearch(
            int toTake, int toSkip, int intervalStart, int intervalEnd, IEnumerable<ISpotUser> users, List<ITimelineEvent> events)
        {
            if (toTake <= 0) return events;

            var spotUsers = users as ISpotUser[] ?? users.ToArray();
            foreach (var user in spotUsers)
            {
                var userEvents = user.MyEvents;
                if (userEvents.IsNullOrEmpty()) continue;

                foreach (var userEvent in userEvents)
                {
                    if (toTake <= 0) return events;

                    if (IsDateInPastInterval(userEvent.StartDateTime, intervalStart, intervalEnd) == false) { continue; }

                    var anEvent = _eventRepository.GetWithId(userEvent.EventId);
                    if (anEvent.Visibility == false) continue;

                    if (toSkip > 0)
                    {
                        toSkip--;
                        continue;
                    }

                    //Step 3 - create timeline event
                    var spot = _spotRepository.GetWithId(anEvent.SpotId);
                    var location = _locationRepository.GetWithId(spot.LocationId);
                    var business = _businessRepository.GetWithId(location.BusinessId);

                    events.Add(new TimelineEventViewModel(user, anEvent, userEvent, spot, location, business));
                    toTake--;
                }
            }

            //Recurtion logic
            if (toTake <= 0) return events;

            if (intervalEnd > 1000) return events;

            //TODO: Adjust increment of end interval
            return GetPastEventsSearch(toTake, toSkip, intervalEnd, intervalEnd + 12, spotUsers, events);
        }

        [Obsolete("Use GetFutureEvents instead")]
        public IEnumerable<ITimelineEvent> GetEvents(int skip, int take)
        {
            var events = new List<ITimelineEvent>();
            var eventCounter = 1;
            var skipCounter = 0;

            //Step 1 - Get {all} users
            var userList = _userRepository.GetAllExceptCurrent;

            //Step 2 - Get all user events, in {past 10 days}
            foreach (var user in userList)
            {
                if (eventCounter > take) continue;

                var userEvents = user.MyEvents;

                if (userEvents.IsNullOrEmpty()) continue;

                foreach (var userEvent in userEvents)
                {
                    if (eventCounter > take) continue;

                    if (IsDateInInterval(userEvent.StartDateTime) == false) { continue;}

                    var anEvent = _eventRepository.GetWithId(userEvent.EventId);

                    if(anEvent.Visibility == false) continue;

                    if (skipCounter < skip)
                    {
                        skipCounter++;
                        continue;
                    }

                    //Step 3 - create timeline event
                    var spot = _spotRepository.GetWithId(anEvent.SpotId);
                    var location = _locationRepository.GetWithId(spot.LocationId);
                    var business = _businessRepository.GetWithId(location.BusinessId);

                    events.Add(new TimelineEventViewModel(user, anEvent, userEvent, spot, location, business));
                    eventCounter++;
                }
            }

            return events.OrderBy(e => e.EventStart).ToList();
        }

        private static bool IsDateInFutureInterval(BsonValue eventStart, int intervalStart, int intervalEnd)
        {
            //TODO: tun this
            var startDate = DateService.ToBson(DateTime.Now.AddHours(intervalStart));
            var endDate = DateService.ToBson(DateTime.Now.AddHours(intervalEnd));

            return eventStart > startDate && eventStart < endDate;
        }

        private static bool IsDateInPastInterval(BsonValue eventStart, int intervalStart, int intervalEnd)
        {
            //TODO: tun this
            var endDate = DateService.ToBson(DateTime.Now.AddHours(intervalStart * -1));
            var startDate = DateService.ToBson(DateTime.Now.AddHours(intervalEnd * -1));

            return eventStart > startDate && eventStart < endDate;
        }

        [Obsolete("Use IsDateInFutureInterval instead.")]
        private static bool IsDateInInterval(BsonValue eventStart)
        {
            var startDate = DateService.GetCurrentBson;
            var endDate = DateService.ToBson(DateTime.Now.AddDays(10));

            return eventStart > startDate && eventStart < endDate;
        }
    }
}