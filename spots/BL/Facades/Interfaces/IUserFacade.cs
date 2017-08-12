using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.User.ViewModels;

namespace spots.BL.Facades.Interfaces
{
    public interface IUserFacade
    {
        UserGroupNameListViewModel GetMyGroupViewModel { get; }
        string GetUserFriendGroupId(string userId);
        string GetUserIdWithEmail(string email);
        string GetUserEmailWithId(string userId);

        IEnumerable<string> GetMyGroupIds { get; }
    }
}
    