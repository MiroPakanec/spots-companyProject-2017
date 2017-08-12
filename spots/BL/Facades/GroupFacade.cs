using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Group;
using spots.DAL.Queries.Repositories.Group;
using spots.Models.Authorisation.Actions.ViewModels;
using spots.Models.Group;
using spots.Models.Group.Interfaces;
using spots.Models.Group.ViewModels;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;
using spots.DAL.Queries.Repositories.SpotUser;

namespace spots.BL.Facades
{
    public class GroupFacade : IGroupFacade
    {
        private readonly IGroup _group;
        private readonly ISpotUser _user;
        private readonly IGroupRepository _repository;
        private readonly ISpotUserRepository _userRepository;
        private readonly IAtomicGroupWork _atomicGroupWork;
        private readonly IGroupResponse _response;

        public GroupFacade(IGroup group, ISpotUser user, IGroupRepository repository, ISpotUserRepository userRepository, IAtomicGroupWork atomicGroupWork, IGroupResponse response)
        {
            _group = group;
            _user = user;
            _repository = repository;
            _userRepository = userRepository;
            _atomicGroupWork = atomicGroupWork;
            _response = response;
        }

        public IGroupResponse CreateGroupResponse(CreateGroupViewModel viewModel)
        {
            try
            {
                //Create
                CreateGroup(viewModel);

                _response.HasSucceeded("Group was created successfully.");
                return _response;
            }
            catch (Exception)
            {
                _response.HasFailed("Group could not be created due to unexpected error, please try again later.");
                return _response;
            }
        }

        public IGroupResponse InvalidModelStateResponse
        {
            get
            {
                _response.HasFailed("Some of the information was not entered correctly.");
                return _response;
            }
        }

        public CreateGroupViewModel GetCreateViewModel(string currentEmail)
        {
            return new CreateGroupViewModel
            {
                CreatedBy = currentEmail
            };
        }

        public GroupDetailsViewModel GetDetailsViewModel(string id)
        {
            var model = _group.Repository.GetWithId(ObjectId.Parse(id));          
            return new GroupDetailsViewModel(model);
        }

        public GroupInformationDetailsViewModel GetInfoDetailsViewModel(string id)
        {
            var model = _group.Repository.GetWithId(ObjectId.Parse(id));
            var members = new List<UserDetailsViewModel>();

            foreach (var memberEmail in model.Members)
            {
                var user = _user.Repository.GetWithEmail(memberEmail);
                var userDetails = new UserDetailsViewModel(user);
                members.Add(userDetails);
            }

            var userRole = _user.Repository.GetCurrent.MyGroups.First(g => g.Id == model.Id).Role;
            var groupRole = model.Roles.First(r => r.Title == userRole);

            var viewModel = new GroupInformationDetailsViewModel(model, groupRole) {Members = members};
            return viewModel;
        }

        public bool IsMember(string userId, string groupId)
        {
            try
            {
                if (userId.IsNullOrWhiteSpace() || groupId.IsNullOrWhiteSpace())
                {
                    return false;
                }

                var email = _userRepository.GetWithId(userId).Email;
                return _repository.IsMember(email, ObjectId.Parse(groupId));
            }
            catch
            {
                throw new Exception("We apologize, unexpecded error has occured.");
            }
        }

        public string AddMember(string email, string groupId)
        {
            try
            {
                if (email.IsNullOrWhiteSpace() || groupId.IsNullOrWhiteSpace())
                {
                    return "Email and group need to be specified.";
                }

                var isMember = _repository.IsMember(email, ObjectId.Parse(groupId));

                if (isMember)
                {
                    return $"User with email {email} is already a member of this group.";
                }

                _repository.AddMember(email, ObjectId.Parse(groupId));
                return "User was added successfully.";
            }
            catch
            {
                return "We apologize, unexpecded error has occured and member could not be added.";
            }
        }

        public string RemoveMember(string email, string groupId)
        {
            try
            {
                if (email.IsNullOrWhiteSpace() || groupId.IsNullOrWhiteSpace())
                {
                    return "Email and group need to be specified.";
                }

                var isMember = _repository.IsMember(email, ObjectId.Parse(groupId));

                if (isMember == false)
                {
                    return $"User with email {email} cannot be removed, because he is not a member of this group.";
                }

                _repository.RemoveMember(email, ObjectId.Parse(groupId));
                return "User was removed successfully.";
            }
            catch
            {
                return "We apologize, unexpecded error has occured and member could not be remvoed.";
            }
        }

        private void CreateGroup(CreateGroupViewModel viewModel)
        {
            try
            {
                var model = viewModel.Group;
                _atomicGroupWork.Add(model as Group);
            }
            catch(Exception e)
            {           
                throw new Exception("Group could not be added.");
            }
        }

        public IEnumerable<UserDetailsViewModel> GetMembers(string groupId)
        {
            var group = _group.Repository.GetWithId(ObjectId.Parse(groupId));
            var members = new List<UserDetailsViewModel>();

            foreach (var memberEmail in group.Members)
            {
                var user = _user.Repository.GetWithEmail(memberEmail);
                var userDetails = new UserDetailsViewModel(user);
                members.Add(userDetails);
            }

            return members;
        }
    }
}