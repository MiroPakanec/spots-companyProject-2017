using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Group.Interfaces;

namespace spots.DAL.Queries.Repositories.Group
{
    public interface IGroupRepository : IRepository<Models.Group.Group>
    {
        void Add(IGroup group);
        void AddMember(string email, ObjectId groupId);
        void RemoveMember(string email, ObjectId groupId);

        IGroup GetWithId(ObjectId id);
        bool IsMember(string email, ObjectId groupId);
    }
}
