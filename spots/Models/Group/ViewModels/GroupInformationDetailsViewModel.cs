using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Authorisation.Actions.ViewModels;
using spots.Models.Authorisation.Roles.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.User.ViewModels;

namespace spots.Models.Group.ViewModels
{
    public class GroupInformationDetailsViewModel
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IGroupRole> Roles { get; set; }
        public GroupActionViewModel Actions { get; set; }


        public IEnumerable<UserDetailsViewModel> Members { get; set; }

        public GroupInformationDetailsViewModel() { }

        public GroupInformationDetailsViewModel(IGroup group, IGroupRole role)
        {
            Id = group.Id;
            Name = group.Name;
            Description = group.Description;
            Roles = group.Roles;
            Actions = Actions = new GroupActionViewModel(role);
        }
    }
}