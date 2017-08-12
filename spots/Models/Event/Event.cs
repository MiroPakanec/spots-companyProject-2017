using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Event;
using spots.Models.Event.Interfaces;

namespace spots.Models.Event
{
    public class Event : IEvent
    {
        private readonly IMongoContextGeneric<Event> _context;

        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public ObjectId SpotId { get; set; }
        public ObjectId BusinessId { get; set; }
        public bool Availability { get; set; }
        public bool Visibility { get; set; }
        public BsonDateTime StartDateTime { get; set; }
        public BsonDateTime EndDateTime { get; set; }
        public List<string> Invited { get; set; }

        public Event() { }

        public Event(IMongoContextGeneric<Event> context)
        {
            _context = context;
        }

        public IEventRepository Repository => new EventRepository(_context);
    }
}