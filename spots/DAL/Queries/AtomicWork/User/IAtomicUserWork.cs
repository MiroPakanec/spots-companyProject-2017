using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Group.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.AtomicWork.User
{
    public interface IAtomicUserWork
    {
        void Add(ISpotUser user, IGroup group);
    }
}
