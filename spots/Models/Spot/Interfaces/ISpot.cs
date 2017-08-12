using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Spot;
using spots.Models.Shared;

namespace spots.Models.Spot.Interfaces
{
    public interface ISpot
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }

        ObjectId LocationId { get; set; }
        string MongoLocationId { get; set; }
       
        string Name { get; set; }
        int Capacity { get; set; }
        bool Visible { get; set; }

        IDictionary<string, IEnumerable<TimeInterval>> DaylyAvailableHours { get; set; }
        ISpotRepository Repository { get; }
    }
}
