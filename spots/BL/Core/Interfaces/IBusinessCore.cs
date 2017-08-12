using spots.Models.Business.Interfaces;
using spots.Models.Spot.Interfaces;

namespace spots.BL.Core.Interfaces
{
    public interface IBusinessCore
    {
        bool IsUserInBusiness(IBusiness business, string email);
        IBusiness GetBusinessWithSpot(ISpot spot);
    }
}
