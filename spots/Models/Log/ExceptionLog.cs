
using System;
using MongoDB.Bson;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Log;

namespace spots.Models.Log
{
    public class ExceptionLog : IExceptionLog
    {
        public ObjectId Id { get; set; }
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionUrl { get; set; }
        public BsonDateTime Date { get; set; }


        private readonly IMongoContextGeneric<ExceptionLog> _context;
        
        public IExceptionLogRepository Repository => new ExceptionLogRepository(_context);

        public ExceptionLog(IMongoContextGeneric<ExceptionLog> context)
        {
            _context = context;
        }

        public ExceptionLog()
        {
            
        }

    }
}



