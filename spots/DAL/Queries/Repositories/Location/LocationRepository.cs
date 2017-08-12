using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Collections;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Location.Interfaces;
using spots.Models.Location.ViewModels;

namespace spots.DAL.Queries.Repositories.Location
{
    public class LocationRepository : Repository<Models.Location.Location>, ILocationRepository
    {
        public LocationRepository(IMongoContextGeneric<Models.Location.Location> mongoContext) : base(mongoContext)
        {
        }

        public ILocation GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(l => l.Id == id).First();
        }

        public ILocation GetWithId(string id)
        {
            return MongoContext.Collection.Find(l => l.Id == ObjectId.Parse(id)).First();
        }

        public ISet<string> GetCitiesStartingWith(string city)
        {
            var set = new HashSet<string>();
            MongoContext.Collection.Find(l => l.City.StartsWith(city)).ToList().ForEach(l => set.Add(l.City));

            return set;
        }

        public async Task<ISet<string>> GetCitiesStartingWithAsync(string city)
        {
            var set = new HashSet<string>();
            await MongoContext.Collection.Find(l => l.City.StartsWith(city)).ForEachAsync(l => set.Add(l.City));

            return set;
        }

        public IEnumerable<ILocation> GetLocationsStartingWith(string city)
        {
            return MongoContext.Collection.Find(l => l.City.StartsWith(city)).ToList();
        }

        public IEnumerable<string> GetSpotIdsInCity(string city)
        {
            var locations = MongoContext.Collection.Find(l => l.City.StartsWith(city)).ToList();
            var allSpots = (from location in locations from spot in location.Spots select spot.ToString()).ToList();

            return allSpots;
        }

        public void Add(ILocation location)
        {
            if (location.Spots == null)
            {
                location.Spots = new List<ObjectId>();
            }

            MongoContext.Collection.InsertOne(location as Models.Location.Location);
        }

        public void AddSpot(ObjectId spotId, ObjectId locationId)
        {
            var filter = Builders<Models.Location.Location>.Filter.Where(l => l.Id == locationId);
            var update = Builders<Models.Location.Location>.Update.Push(LocationCollections.Spots, spotId);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddSpot(string spotId, string locationId)
        {
            var filter = Builders<Models.Location.Location>.Filter.Where(l => l.Id == ObjectId.Parse(locationId));
            var update = Builders<Models.Location.Location>.Update.Push(LocationCollections.Spots, ObjectId.Parse(spotId));

            MongoContext.Collection.UpdateOne(filter, update);
        }
    }
}