using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager.MongoContext;
using DbManager.SqlContext;

namespace DbManager
{
    internal class CommandController
    {       
        internal bool DeleteAll()
        {
            var sqlResult = Sql.DeleteAll();
            var mongoResult = Mongo.DelteAll();

            return sqlResult && mongoResult;
        }

        internal bool Populate()
        {
            var sqlResult = Sql.PopulateDefault();
            var mongoResult = Mongo.PopulateDefault();

            return sqlResult.Result;
        }
    }
}
