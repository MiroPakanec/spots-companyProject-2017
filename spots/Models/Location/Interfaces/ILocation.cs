using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Location;

namespace spots.Models.Location.Interfaces
{
    public interface ILocation
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }

        ObjectId BusinessId { get; set; }

        string MongoBusinessId { get; set; }

        string Address { get; set; }
        string Zip { get; set; }
        string City { get; set; }
        string Country { get; set; }
        IList<ObjectId> Spots { get; set; }

        ILocationRepository Repository { get; }
            
        string FullAddress { get; }
    }
}
