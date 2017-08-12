using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Log;

namespace spots.DAL.Queries.Repositories.Log
{
    public interface ILogRepository : IRepository<Models.Log.Log>
    {
        void StoreActivity(Models.Log.Log log);
    }
}
