using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Group;
using spots.Models.Authorisation.Roles;
using spots.Models.Authorisation.Roles.Interfaces;
using spots.Models.Business.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.Models.Group.Interfaces
{
    public interface IGroup
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        IEnumerable<ObjectId> Events { get; set; }
        IEnumerable<string> Members { get; set; }
        IEnumerable<GroupRole> Roles { get; set; }

        IGroupRepository Repository { get; }

        IGroup CreateDefaultUserGroup(ISpotUser user);
        IGroup CreateDefaultBusinessGroup(IBusiness business);
    }
}
