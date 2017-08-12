using MongoDB.Bson;
using spots.Models.Event.Interfaces;

namespace spots.Models.User.Interfaces
{
    public interface IUserEvent
    {
        ObjectId EventId { get; set; }
        BsonDateTime StartDateTime { get; set; }
        BsonDateTime Joined { get; set; }

        IUserEvent InitializeFromEvent(IEvent myEvent);
        IUserEvent GetUserEvent(ObjectId eventId, ObjectId userId);
    }
}
