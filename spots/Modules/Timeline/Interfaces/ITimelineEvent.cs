using MongoDB.Bson;

namespace spots.Modules.Timeline.Interfaces
{
    public interface ITimelineEvent
    {
        ObjectId UserId { get; set; }
        ObjectId EventId { get; set; }
        ObjectId SpotId { get; set; }
        ObjectId LocationId { get; set; }
        ObjectId BusinessId { get; set; }

        string FirstName { get; set; }

        string EventTitle { get; set; }
        string EventStart { get; set; }
        string Joined { get; set; }

        string SpotName { get; set; }

        string Address { get; set; }
        string City { get; set; }
        string Zip { get; set; }
        string Country { get; set; }

        string BusinessName { get; set; }
    }
}
