using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Event.Interfaces;
using spots.Services.DateService;

namespace spots.DAL.Queries.Repositories.Event
{
    public class EventRepository : Repository<Models.Event.Event>, IEventRepository
    {
        public EventRepository(IMongoContextGeneric<Models.Event.Event> mongoContext) : base(mongoContext)
        {
        }

        public IEvent GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(e => e.Id == id).First();
        }

        public IEvent GetWithId(string id)
        {
            return MongoContext.Collection.Find(e => e.Id == ObjectId.Parse(id)).First();
        }

        public IEnumerable<string> GetOccupiedSpotIds(string city, BsonDateTime startDateTime, BsonDateTime endDateTime)
        {
            var spots = new List<string>();

            var builder = Builders<Models.Event.Event>.Filter;
            var filter = builder.Lt(e => e.StartDateTime, endDateTime)
                         & builder.Gt(e => e.EndDateTime, startDateTime)
                         & builder.Eq(e => e.City, city);

            var events = MongoContext.Collection.Find(filter).ToList();

            events.ForEach(s => spots.Add(s.SpotId.ToString()));
            return spots;
        }

        public IEnumerable<IEvent> GetByLocationAndTime(string city, BsonDateTime date)
        {
            try
            {
                //TODO: DATE FIX
                var dateIntervalStart = date.ToUniversalTime().Date.AddDays(1);
                var dateIntervalEnd = date.ToUniversalTime().Date.AddDays(2);

                var builder = Builders<Models.Event.Event>.Filter;
                var filter = 
                    builder.Gte(e => e.StartDateTime, dateIntervalStart) &
                    builder.Lte(e => e.StartDateTime, dateIntervalEnd) &
                    builder.Eq(e => e.City, city);

                return MongoContext.Collection.Find(filter).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public IEnumerable<ObjectId> GetEventSpots(string city, BsonDateTime startDateTime,
            BsonDateTime endDateTime)
        {
            try
            {
                var builder = Builders<Models.Event.Event>.Filter;
                var filter =
                        builder.Gte(e => e.StartDateTime, startDateTime.ToUniversalTime()) &
                        builder.Lte(e => e.StartDateTime, endDateTime.ToUniversalTime()) &
                        builder.Eq(e => e.City, city);

                return MongoContext.Collection.Find(filter).Project(p => p.SpotId).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public IEnumerable<IEvent> GetEventsBySpotId(ObjectId spotId)
        {
            try
            {
                var collection = MongoContext.Collection
                    .Find(e => e.SpotId == spotId)
                    .ToList(); 

                return collection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IEvent> GetByDay(BsonDateTime date)
        {
            try
            {
                var dateIntervalStart = date.ToUniversalTime().Date.AddDays(1);
                var dateIntervalEnd = date.ToUniversalTime().Date.AddDays(2);

                var builder = Builders<Models.Event.Event>.Filter;
                var filter =
                    builder.Gte(e => e.StartDateTime, dateIntervalStart) &
                    builder.Lte(e => e.StartDateTime, dateIntervalEnd);

                return MongoContext.Collection.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<IEvent> GetByBusiness(ObjectId businessId)
        {
            try
            {
                var collection = MongoContext.Collection
                    .Find(e => e.BusinessId == businessId)
                    .ToList();

                return collection.OrderByDescending(e => e.Invited.Count).Take(5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(IEvent anEvent)
        {
            if (HasAvailableSpot(anEvent))
            {
                MongoContext.Collection.InsertOne(anEvent as Models.Event.Event);
            }
        }

        public bool HasAvailableSpot(IEvent anEvent)
        {
            var builder = Builders<Models.Event.Event>.Filter;
            var filter = builder.Lt(e => e.StartDateTime, anEvent.EndDateTime)
                        & builder.Gt(e => e.EndDateTime, anEvent.StartDateTime)
                        & builder.Eq(e => e.SpotId, anEvent.Id);

            return MongoContext.Collection.Find(filter).Count() <= 0;
        }
    }
}