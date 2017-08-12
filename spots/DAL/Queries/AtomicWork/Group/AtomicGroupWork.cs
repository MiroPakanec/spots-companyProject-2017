using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Authorisation.Roles;
using spots.Models.Group.Interfaces;
using spots.Models.User;

namespace spots.DAL.Queries.AtomicWork.Group
{
    public class AtomicGroupWork : AtomicWork, IAtomicGroupWork
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ISpotUserRepository _userRepository;

        public AtomicGroupWork(IGroupRepository groupRepository, ISpotUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public override string Desc => "Atomic group work.";

        public void Add(IGroup group)
        {
            _groupRepository.Add(group);

            var currentUser = _userRepository.GetCurrent;

            foreach (var memberEmail in group.Members)
            {
                var userGroup = new UserGroup
                {
                    Id = @group.Id,
                    Name = @group.Name,
                    Role = memberEmail == currentUser.Email ? GroupRoles.Admin : GroupRoles.Member,
                };

                _userRepository.AddGroupWithEmail(userGroup, memberEmail);
            }
        }
    }
}