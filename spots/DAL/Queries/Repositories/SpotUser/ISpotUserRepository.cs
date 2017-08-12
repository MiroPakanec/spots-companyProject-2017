using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;

namespace spots.DAL.Queries.Repositories.SpotUser
{
    public interface ISpotUserRepository : IRepository<Models.User.SpotUser>
    {
        ISpotUser GetWithEmail(string email);
        ISpotUser GetWithId(ObjectId id);
        ISpotUser GetWithId(string id);
        IEnumerable<IUserBusiness> GetUserBusinesses(string email);
        IEnumerable<IUserEvent> GetUserEvents(string email);
            
        IEnumerable<ISpotUser> GetAllWithPartialEmail(string email);
        IEnumerable<ISpotUser> GetAllExceptCurrent { get; }
        ISpotUser GetCurrent { get; }
        ObjectId GetCurrentId { get; }

        void Update(ISpotUser user);
        void Update(UserDetailsViewModel user);
        void UpdatePersonal(UserPersonalViewModel user);
        void UpdateContact(UserContactViewModel user);

        void AddBusinessWithId(IUserBusiness userBusiness, ObjectId id);
        void AddBusinessWithEmail(IUserBusiness userBusiness, string email);
        void AddBusinessForManyWithEmail(IUserBusiness userBusiness, IList<string> userEmails);

        void AddGroupWithEmail(IUserGroup userGroup, string email);

        void AddEventWithId(IUserEvent userEvent, ObjectId id);
        void AddEventWithEmail(IUserEvent userEvent, string email);
        void AddEventForMany(IUserEvent userEvent, IList<string> userIds);
        void AddEventForMany(IUserEvent userEvent, IList<ObjectId> userIds);
        void AddEventForManyWithEmail(IUserEvent userEvent, IList<string> userEmails);

        Task<ISpotUser> GetWithEmailAsync(string email);
        Task<ISpotUser> GetWithIdAsync(ObjectId id);
        Task<ISpotUser> GetWithIdAsync(string id);
        Task<IEnumerable<IUserBusiness>> GetUserBusinessesAsync(string email);

    }
}
