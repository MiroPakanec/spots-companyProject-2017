using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Group.Interfaces;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;
using spots.DAL.Queries.Repositories.SpotUser;
using MongoDB.Bson;

namespace spots.BL.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly ISpotUser _user;
        private readonly ISpotUserRepository _repository;    

        public UserFacade(ISpotUser user, ISpotUserRepository repository)
        {
            _user = user;
            _repository = repository;
        }


        public UserGroupNameListViewModel GetMyGroupViewModel
        {
            get
            {
                var viewModel = new UserGroupNameListViewModel {UserGroups = new List<UserGroup>()};
                var userGroups = _user.Repository.GetCurrent.MyGroups;

                viewModel.UserGroups = userGroups;

                return viewModel;             
            }
        }

        public IEnumerable<string> GetMyGroupIds
        {
            get
            {
                var userGroups = _user.Repository.GetCurrent.MyGroups;
                return userGroups
                    .Select(userGroup => userGroup.Id.ToString())
                    .ToList();
            }
        }

        public string GetUserFriendGroupId(string userId)
        {
            var groups = _repository.GetWithId(ObjectId.Parse(userId)).MyGroups;

            foreach (var group in groups)
            {
                if(group.Name == "friends")
                {
                    return group.MongoId;
                }
            }

            throw new NullReferenceException("User does not have a friend group.");
        }

        public string GetUserIdWithEmail(string email)
        {
            return _repository.GetWithEmail(email).Id.ToString();
        }

        public string GetUserEmailWithId(string userId)
        {
            return _repository.GetWithId(userId).Email;
        }

        public bool HasUserBusiness(string email)
        {
            var businesses = _repository.GetUserBusinesses(email);
            return businesses.IsNullOrEmpty();
        }
    }
}