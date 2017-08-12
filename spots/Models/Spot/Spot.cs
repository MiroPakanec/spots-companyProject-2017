using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Spot;
using spots.Models.Shared;
using spots.Models.Spot.Interfaces;

namespace spots.Models.Spot
{
    public class Spot : ISpot
    {
        private readonly IMongoContextGeneric<Spot> _context;

        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string MongoId { get; set; }

        public ObjectId LocationId { get; set; }

        [BsonIgnore]
        public string MongoLocationId
        {
            get { return LocationId.ToString(); }
            set { LocationId = ObjectId.Parse(value); }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool Visible { get; set; }

        public IDictionary<string, IEnumerable<TimeInterval>> DaylyAvailableHours { get; set; }
        

        public Spot() { }

        public Spot(IMongoContextGeneric<Spot> context)
        {
            _context = context;
        }

        public ISpotRepository Repository => new SpotRepository(_context);

        public bool HasValidAvailableHours => TimeIntervalValidation.HasValidDaylyTimeIntervals(DaylyAvailableHours);
    }
}