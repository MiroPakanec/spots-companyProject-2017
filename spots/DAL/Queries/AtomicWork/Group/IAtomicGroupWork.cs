using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Group.Interfaces;

namespace spots.DAL.Queries.AtomicWork.Group
{
    public interface IAtomicGroupWork : IAtomicWork
    {
        void Add(IGroup group);
    }
}
