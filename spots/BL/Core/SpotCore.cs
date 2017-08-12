using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.BL.Core.Interfaces;
using spots.DAL.Queries.AtomicWork.Event;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Authorisation.Actions;
using spots.Models.Business.Interfaces;
using spots.Models.Event.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.Spot;
using spots.Models.Spot.Interfaces;
using spots.Models.Spot.ViewModels;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Services.DateService;

namespace spots.BL.Core
{
    public class SpotCore: ISpotCore
    {

        private readonly ISpotUserRepository _spotUserRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ISpotRepository _spotRepository;
        private readonly IEventRepository _eventRepository;

        public SpotCore(ISpotUserRepository spotUserRepository, IGroupRepository groupGroupRepository,
            IBusinessRepository businessRepository,
            ILocationRepository locationRepository, ISpotRepository spotRepository,
            IEventRepository eventRepository)
        {
            _spotUserRepository = spotUserRepository;
            _groupRepository = groupGroupRepository;
            _businessRepository = businessRepository;
            _locationRepository = locationRepository;
            _spotRepository = spotRepository;
            _eventRepository = eventRepository;
        }

        public IEnumerable<IAvailableSpot> GetAvailableSpotsInCity(string city, BsonDateTime starDateTime, BsonDateTime endDateTime)
        {
            try
            {
                var spots = GetSpotObjects(city, starDateTime, endDateTime);
                return GetAvailableSpotObject(spots);
            }
            catch (Exception)
            {
                throw new Exception("Failed to perform atomic action GetAvailableSpotsInCity - " + " SpotCore work.");
            }
        }

        public IEnumerable<ISpot> GetSpotObjects(string city, BsonDateTime starDateTime,
            BsonDateTime endDateTime)
        {
            var allSpotIds = _locationRepository.GetSpotIdsInCity(city).ToList();
            //todo should be moved and changed 
            //var occupiedSpots = _eventRepository.GetOccupiedSpotIds(city, starDateTime, endDateTime);
            //occupiedSpots.ForEach(s => allSpotIds.Remove(s));

            var spots = new List<ISpot>();

            foreach (var spotId in allSpotIds)
            {
                var spot = _spotRepository.GetWithId(spotId);
                //
                 if(!IsSpotAvaible(starDateTime, endDateTime, spot)) continue;
                
                if (IsSpotOccupied(spot, starDateTime, endDateTime)) continue;

                var isSpotVisible = IsSpotVisible(spot);
                if (!isSpotVisible)
                {
                    var location = _locationRepository.GetWithId(spot.LocationId);
                    var business = _businessRepository.GetWithId(location.BusinessId);
                    var user = _spotUserRepository.GetCurrent;

                    if (!IsUserBusinessMember(user.Email, business)) continue;
                    if (CanUserViewSpot(user, business) == false) continue;
                    
                    spots.Add(spot);
                    continue;                   
                }

                spots.Add(spot);
            }
            return spots;
        }

        public bool IsSpotOccupied(ISpot spot, BsonDateTime starDateTime,
            BsonDateTime endDateTime)
        {
            var events = _eventRepository.GetEventsBySpotId(spot.Id);
            foreach (var @event in events)
            {
                if (IsThereOverlapping(@event, starDateTime, endDateTime)) return true;
            }
            return false;
        }

        public bool IsThereOverlapping(IEvent @event, BsonDateTime starDateTime,
            BsonDateTime endDateTime)
        {
            return @event.StartDateTime.ToLocalTime() <= endDateTime.ToLocalTime() &&
                   starDateTime.ToLocalTime() <= @event.EndDateTime.ToLocalTime();
        }

        public bool IsSpotAvaible(BsonDateTime starDateTime, BsonDateTime endDateTime, ISpot spot)
        {

            if (starDateTime.ToLocalTime().Day == endDateTime.ToLocalTime().Day)
            {

                foreach (var daylyAvailableHour in spot.DaylyAvailableHours[starDateTime.ToLocalTime().ToString("dddd", new CultureInfo("en-US"))]
                )
                {

                    if (daylyAvailableHour.From.ToLocalTime().TimeOfDay <= starDateTime.ToLocalTime().TimeOfDay &&
                        daylyAvailableHour.To.ToLocalTime().TimeOfDay >= endDateTime.ToLocalTime().TimeOfDay)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var timeInterval in spot.DaylyAvailableHours[starDateTime.ToLocalTime().ToString("dddd", new CultureInfo("en-US"))])
                {
                   
                    var date = starDateTime.ToLocalTime().AddDays(1);
                    var mid = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

                    if (timeInterval.From.ToLocalTime().TimeOfDay > starDateTime.ToLocalTime().TimeOfDay ||
                        timeInterval.To.ToLocalTime().TimeOfDay != mid.TimeOfDay) continue;

                    //check second day
                    foreach (var interval in spot.DaylyAvailableHours[endDateTime.ToLocalTime().ToString("dddd", new CultureInfo("en-US"))])
                    {
                        if (interval.From.ToLocalTime().TimeOfDay.Equals(mid.TimeOfDay) &&
                            interval.To.ToLocalTime().TimeOfDay >= endDateTime.ToLocalTime().TimeOfDay)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool IsSpotVisible(ISpot spot)
        {
            return spot.Visible;
        }

        public bool IsUserBusinessMember(string email, IBusiness business)
        {
            return business.Members.Contains(email);
        }

        public bool CanUserViewSpot(ISpotUser user, IBusiness business)
        {
            foreach (var userGroup in user.MyGroups)
            {
                var groupId = userGroup.Id.ToString();
                if (groupId != business.Group.ToString()) continue;

                var group = _groupRepository.GetWithId(business.Group);

                if (CheckPrivilegeViewSpot(group, userGroup))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckPrivilegeViewSpot(IGroup group, IUserGroup userGroup)
        {
            foreach (var role in @group.Roles)
            {
                if (role.Title == userGroup.Role && role.ActionDictionary[GroupActions.ViewSpot])
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<ObjectId> SpotsIdsWithLocation(ILocation location)
        {
            var spotsIds = new List<ObjectId>();

            foreach (var spotId in location.Spots)
            {
                var spot = _spotRepository.GetWithId(spotId);
                var isSpotVisible = IsSpotVisible(spot);

                if (isSpotVisible)
                {
                    spotsIds.Add(spotId);
                    continue;
                }

                var business = _businessRepository.GetWithId(location.BusinessId);
                var user = _spotUserRepository.GetCurrent;

                if (IsUserBusinessMember(user.Email, business) == false) continue;
                if (CanUserViewSpot(user, business) == false) continue;

                spotsIds.Add(spotId);                
            }
            return spotsIds;
        }

        private IEnumerable<IAvailableSpot> GetAvailableSpotObject(IEnumerable<ISpot> spots)
        {
            var available = (from spot in spots
                             let location = _locationRepository.GetWithId(spot.LocationId)
                             let business = _businessRepository.GetWithId(location.BusinessId)
                             select new AvailableSpotsViewModel
                             {
                                 BusinessName = business.Name,
                                 BusinessId = business.MongoId,
                                 SpotName = spot.Name,
                                 SpotId = spot.Id.ToString(),
                                 Capacity = spot.Capacity,
                                 Address = location.Address,
                                 City = location.City,
                                 Zip = location.Zip,
                                 Country = location.Country
                             }).ToList();
            return available;
        }
    }


}