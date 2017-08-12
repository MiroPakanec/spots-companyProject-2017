using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Log;

namespace spots.DAL.Queries.Repositories.Log
{
    public class LogRepository : Repository<Models.Log.Log>, ILogRepository
    {
        public LogRepository(IMongoContextGeneric<Models.Log.Log> mongoContext) : base(mongoContext)
        {
        }

        public void StoreActivity(Models.Log.Log log)
        {
            MongoContext.Collection.InsertOne(log);
        }
    }
}