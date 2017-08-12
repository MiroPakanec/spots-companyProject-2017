using spots.Models.Location.Interfaces;
using spots.Models.Location.ViewModels;

namespace spots.DAL.Queries.AtomicWork.Location
{
    public interface IAtomicLocationWork : IAtomicWork
    {
        void Add(ILocation location);
        void Add(CreateLocationViewModel location);
    }
}
