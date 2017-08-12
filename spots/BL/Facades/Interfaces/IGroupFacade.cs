using spots.Models.Group.Interfaces;
using spots.Models.Group.ViewModels;
using spots.Models.User.ViewModels;
using System.Collections.Generic;

namespace spots.BL.Facades.Interfaces
{
    public interface IGroupFacade
    {
        IGroupResponse CreateGroupResponse(CreateGroupViewModel viewModel);
        IGroupResponse InvalidModelStateResponse { get; }

        CreateGroupViewModel GetCreateViewModel(string currentEmail);
        GroupDetailsViewModel GetDetailsViewModel(string id);
        GroupInformationDetailsViewModel GetInfoDetailsViewModel(string id);

        bool IsMember(string userId, string groupId);
        string AddMember(string email, string groupId);
        string RemoveMember(string email, string groupId);

        IEnumerable<UserDetailsViewModel> GetMembers(string groupId);
    }
}
