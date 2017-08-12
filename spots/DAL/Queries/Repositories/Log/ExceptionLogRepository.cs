using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.DAL.Queries.Repositories.Log;
using spots.Models.Log;

namespace spots.DAL.Queries.Repositories.Log
{
    public class ExceptionLogRepository: Repository<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(IMongoContextGeneric<ExceptionLog> mongoContext) : base(mongoContext)
        {
        }

        public void StoreActivity(ExceptionLog exceptionLog)
        {
            MongoContext.Collection.InsertOne(exceptionLog);
        }
    }
}