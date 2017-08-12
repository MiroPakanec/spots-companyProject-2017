using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Spot;
using spots.DAL.Queries.AtomicWork.User;
using spots.Models.Account.Interfaces;
using spots.Models.Account.Viewmodels;
using spots.Models.Authorisation.Roles;
using spots.Models.Group.Interfaces;
using spots.Models.Identity;
using spots.Models.User;
using spots.Models.User.Interfaces;

namespace spots.BL.Facades
{
    public class AccountFacade : IAccountFacade
    {
        private readonly IGroup _group;
        private readonly IExceptionLogFacade _exceptionLogFacade;
        private readonly IAtomicUserWork _atomicUserWork;

        public AccountFacade(IGroup group, IAtomicUserWork atomicUserWork, IExceptionLogFacade exceptionLogFacade)
        {
            _group = group;
            _atomicUserWork = atomicUserWork;
            _exceptionLogFacade = exceptionLogFacade;
        }


        public void Register(RegisterViewModel viewModel)
        {
            var user = viewModel.GetSpotUser as SpotUser;
            var group = _group.CreateDefaultUserGroup(user);
            group.Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>;

            var userGroup = new UserGroup
            {
                Id = group.Id,
                Name = group.Name,
                Role = GroupRoles.Admin
            };

            var userGroups = new List<UserGroup>
            {
                userGroup
            };

            if (user == null)
            {
                throw new NullReferenceException("Spot user model cannot be null.");
            }

            user.MyGroups = userGroups;
            _atomicUserWork.Add(user, group);
        }
    }
}