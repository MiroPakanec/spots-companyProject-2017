using MongoDB.Bson;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Log;

namespace spots.Models.Log
{
    public class Log : ILog
    {
        private readonly IMongoContextGeneric<Log> _context;


        public string ButtonName { get; set; }
        public string ButtonId { get; set; }
        public string ButtonLink { get; set; }
        public string ButtonText { get; set; }

        public string CurrentPage { get; set; }
        public string Email { get; set; }
        public BsonDateTime DateTime { get; set; }

        public ILogRepository Repository => new LogRepository(_context);

        public Log(IMongoContextGeneric<Log> context)
        {
            _context = context;
        }

        public Log() { }
    }
}