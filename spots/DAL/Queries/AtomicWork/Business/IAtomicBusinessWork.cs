using spots.Models.Business.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Business
{
    public interface IAtomicBusinessWork : IAtomicWork
    {
        void Add(IBusiness business, ILocation location, IUserBusiness userBusiness, IGroup group);
    }
}
