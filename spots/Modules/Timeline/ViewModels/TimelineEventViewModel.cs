using MongoDB.Bson;
using spots.Models.Business.Interfaces;
using spots.Models.Event.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Models.User.Interfaces;
using spots.Modules.Timeline.Interfaces;
using spots.Services.DateService;

namespace spots.Modules.Timeline.ViewModels
{
    public class TimelineEventViewModel : ITimelineEvent
    {
        public ObjectId UserId { get; set; }
        public ObjectId EventId { get; set; }
        public ObjectId SpotId { get; set; }
        public ObjectId LocationId { get; set; }
        public ObjectId BusinessId { get; set; }

        public string MongoUserId
        {
            get { return UserId.ToString(); }
            set { UserId = ObjectId.Parse(value); }
        }

        public string MongoEventId
        {
            get { return EventId.ToString(); }
            set { EventId = ObjectId.Parse(value); }
        }

        public string MongoSpotId
        {
            get { return SpotId.ToString(); }
            set { SpotId = ObjectId.Parse(value); }
        }

        public string MongoLocationId
        {
            get { return LocationId.ToString(); }
            set { LocationId = ObjectId.Parse(value); }
        }

        public string MongoBusinessId
        {
            get { return BusinessId.ToString(); }
            set { BusinessId = ObjectId.Parse(value); }
        }

        public string FirstName { get; set; }

        public string EventTitle { get; set; }
        public string EventStart { get; set; }
        public string Joined { get; set; }

        public string SpotName { get; set; }

        public string Address { get; set; }      
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public string BusinessName { get; set; }

        public  TimelineEventViewModel()
        {
        }

        public TimelineEventViewModel(ISpotUser user, IEvent myEvent, IUserEvent userEvent, ISpot spot,
            ILocation location, IBusiness business)
        {
            UserId = user.Id;
            EventId = myEvent.Id;
            SpotId = spot.Id;
            LocationId = location.Id;
            BusinessId = business.Id;

            FirstName = user.FirstName;
            EventTitle = myEvent.Title;
            EventStart = myEvent.StartDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat);

            Joined = DateService.GetRelativeSpan(userEvent.Joined.ToUniversalTime()
                .ToString(DateService.GetBasicDateTimeFormat));

            SpotName = spot.Name;
            Address = location.Address;
            City = location.City;
            Zip = location.Zip;
            Country = location.Country;

            BusinessName = business.Name;
        }
    }
}