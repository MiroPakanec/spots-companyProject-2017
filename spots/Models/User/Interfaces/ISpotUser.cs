using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Business.Interfaces;
using spots.Models.Event.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location.Interfaces;

namespace spots.Models.User.Interfaces
{
    public interface ISpotUser
    {
        ObjectId Id { get; set; }
        string MongoId { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Phone { get; set; }
        string City { get; set; }
        IList<UserBusiness> MyBusinesses { get; set; }
        IList<UserEvent> MyEvents { get; set; }
        IEnumerable<UserGroup> MyGroups { get; set; }

        ISpotUserRepository Repository { get; }
        IUserEvent UserEvent(IEvent uEvent);
        IUserBusiness UserBusiness(IBusiness business, ILocation location);
    }
}
