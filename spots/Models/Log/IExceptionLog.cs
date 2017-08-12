using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.DAL.Queries.Repositories.Log;

namespace spots.Models.Log
{
    public interface IExceptionLog
    {
        IExceptionLogRepository Repository { get; }
    }
}
