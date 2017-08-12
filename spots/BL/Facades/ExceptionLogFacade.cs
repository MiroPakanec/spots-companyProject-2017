using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.Models.Log;
using spots.Services.DateService;

namespace spots.BL.Facades
{
    public class ExceptionLogFacade: IExceptionLogFacade    
    {
        private readonly IExceptionLog _exceptionLog;

        public ExceptionLogFacade(IExceptionLog exceptionLog)
        {
            _exceptionLog = exceptionLog;
        }

        public ExceptionLogFacade()
        {
            
        }

        public void StoreException(Exception exception)
        {
            var exceptionLog = new ExceptionLog
            {
                Date = DateService.ToBson(DateTime.Now),
                ExceptionSource = exception.Source,
                ExceptionType = exception.GetType().Name,
                Message = exception.Message,
                ExceptionUrl = exception.StackTrace
            };

           _exceptionLog.Repository.StoreActivity(exceptionLog);
        }
       



       
    }
}