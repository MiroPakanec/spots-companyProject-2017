using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Spot.Interfaces;

namespace spots.DAL.Queries.Repositories.Spot
{
    public class SpotRepository : Repository<Models.Spot.Spot>, ISpotRepository
    {
        public SpotRepository(IMongoContextGeneric<Models.Spot.Spot> mongoContext) : base(mongoContext)
        {
        }

        public ISpot GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(s => s.Id == id).First();
        }

        public ISpot GetWithId(string id)
        {
            return MongoContext.Collection.Find(s => s.Id == ObjectId.Parse(id)).First();
        }

        public void Add(ISpot spot)
        {
            MongoContext.Collection.InsertOne(spot as Models.Spot.Spot);
        }
    }
}