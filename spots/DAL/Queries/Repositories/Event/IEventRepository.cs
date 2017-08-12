using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Event.Interfaces;

namespace spots.DAL.Queries.Repositories.Event
{
    public interface IEventRepository : IRepository<Models.Event.Event>
    {
        IEvent GetWithId(ObjectId id);
        IEvent GetWithId(string id);
        IEnumerable<string> GetOccupiedSpotIds(string city, BsonDateTime startDateTime, BsonDateTime endDateTime);
        IEnumerable<ObjectId> GetEventSpots(string city, BsonDateTime startDateTime, BsonDateTime endDateTime);

        IEnumerable<IEvent> GetByLocationAndTime(string city, BsonDateTime date);
        IEnumerable<IEvent> GetByDay(BsonDateTime date);
        IEnumerable<IEvent> GetByBusiness(ObjectId businessId);

        IEnumerable<IEvent> GetEventsBySpotId(ObjectId spotId);

        void Add(IEvent anEvent);

        bool HasAvailableSpot(IEvent anEvent);
    }
}
