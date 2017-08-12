using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace spots.Models.User.ViewModels
{
    public class UserGroupNameListViewModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
    }
}