using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Location;
using spots.Models.Location.Interfaces;

namespace spots.Models.Location
{
    public class Location : ILocation
    {
        private readonly IMongoContextGeneric<Location> _context;

        public ObjectId Id { get; set; }

        [BsonIgnore]
        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public ObjectId BusinessId { get; set; }

        [BsonIgnore]
        public string MongoBusinessId
        {
            get { return BusinessId.ToString(); }
            set { BusinessId = ObjectId.Parse(value); }
        }

        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IList<ObjectId> Spots { get; set; }

        public Location() { }

        public Location(IMongoContextGeneric<Location> context)
        {
            _context = context;

            Spots = new List<ObjectId>();
        }

        public ILocationRepository Repository => new LocationRepository(_context);

        public string FullAddress => $"{Address} {City} {Zip} {Country}";
    }
}