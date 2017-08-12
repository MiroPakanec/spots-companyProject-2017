using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Group;
using spots.Models.Group.Interfaces;
using spots.Models.User;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.AtomicWork.User
{
    public class AtomicUserWork : AtomicWork, IAtomicUserWork
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ISpotUserRepository _userRepository;

        public AtomicUserWork(ISpotUserRepository userRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
        }

        public void Add(ISpotUser user, IGroup group)
        {
            try
            {
                Lock();

                _userRepository.Add(user as SpotUser);
                _groupRepository.Add(group as Models.Group.Group);
            }
            catch (Exception)
            {
                //TODO: Rollback logic
                throw new Exception("Failed to perform atomic action Add - " + Desc);
            }
            finally
            {
                Unlock();
            }
        }

        public override string Desc => "Atomic user work.";
    }
}