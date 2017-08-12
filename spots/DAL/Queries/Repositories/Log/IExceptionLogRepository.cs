using spots.DAL.Queries.Repositories.Core;

namespace spots.DAL.Queries.Repositories.Log
{
    public interface IExceptionLogRepository: IRepository<Models.Log.ExceptionLog>
    {
        void StoreActivity(Models.Log.ExceptionLog exceptionLog);
    }
}
