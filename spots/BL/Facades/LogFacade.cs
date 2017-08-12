    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.BL.Facades.Interfaces;
using spots.DAL.Mongo.Context;
using spots.Models.Log;
using spots.Services.DateService;

namespace spots.BL.Facades
{
    public class LogFacade : ILogFacade
    {
        private readonly ILog _log;

        public LogFacade(ILog log)
        {
            _log = log;
        }

        public void StoreActivity(Log log)
        {
            
            log.DateTime = DateService.GetCurrentBson;
            _log.Repository.StoreActivity(log);
        }
    }
}