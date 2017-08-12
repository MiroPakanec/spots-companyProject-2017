using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Location.Interfaces;
using spots.Models.Location.ViewModels;

namespace spots.DAL.Queries.Repositories.Location
{
    public interface ILocationRepository : IRepository<Models.Location.Location>
    {
        ILocation GetWithId(ObjectId id);
        ILocation GetWithId(string id);
        
        ISet<string> GetCitiesStartingWith(string city);
        Task<ISet<string>> GetCitiesStartingWithAsync(string city);

        IEnumerable<ILocation> GetLocationsStartingWith(string city);
        IEnumerable<string> GetSpotIdsInCity(string city);

        void Add(ILocation location);

        void AddSpot(ObjectId spotId, ObjectId locationId);
        void AddSpot(string spotId, string locationId);
    }
}
