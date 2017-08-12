using spots.Models.Log;

namespace spots.BL.Facades.Interfaces
{
    public interface ILogFacade
    {
        void StoreActivity(Log log);
    }
}
