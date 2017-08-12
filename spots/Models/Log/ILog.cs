using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Log;

namespace spots.Models.Log
{
    public interface ILog
    {
        BsonDateTime DateTime { get; set; }
        ILogRepository Repository { get; }
    }
}