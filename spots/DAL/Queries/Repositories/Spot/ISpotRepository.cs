using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Spot.Interfaces;

namespace spots.DAL.Queries.Repositories.Spot
{
    public interface ISpotRepository : IRepository<Models.Spot.Spot>
    {
        ISpot GetWithId(ObjectId id);
        ISpot GetWithId(string id);

        void Add(ISpot spot);
    }
}
