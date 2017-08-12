using spots.Modules.Map.Models;

namespace spots.BL.Facades.Interfaces
{
    public interface IMapFacade
    {
        MapLocation GetMapLocationViewModel(string latitude, string longitude);
        MapDetailsViewModel GetMapDetailsViewModel(MapFilter filter);
    }
}
