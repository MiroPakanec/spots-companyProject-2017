using System.Collections.Generic;
using Castle.Core.Internal;
using spots.Models.Authorisation.Roles;
using spots.Models.Authorisation.Roles.Interfaces;

namespace spots.Models.Authorisation.Actions.ViewModels
{
    public class GroupActionViewModel
    {
        public bool AddMember { get; set; }
        public bool RemoveMember { get; set; }
        public bool ViewMember { get; set; }

        public GroupActionViewModel(IGroupRole groupRole)
        {
            var actions = groupRole.ActionDictionary;

            AddMember = actions[GroupActions.AddMember];
            RemoveMember = actions[GroupActions.RemoveMember];
            ViewMember = actions[GroupActions.ViewMember];
        }
    }
}