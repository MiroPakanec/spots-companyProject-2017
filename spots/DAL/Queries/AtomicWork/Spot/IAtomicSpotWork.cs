using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Spot.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Spot
{
    public interface IAtomicSpotWork : IAtomicWork
    {
       
        IEnumerable<string> GetAvailableSpotIdsInCity(string city, BsonDateTime starDateTime, BsonDateTime endDateTime);

        void Add(ISpot spot);
    }
}
