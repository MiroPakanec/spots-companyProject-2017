using System.Collections.Generic;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Business.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.DAL.Queries.Repositories.Business
{
    public interface IBusinessRepository : IRepository<Models.Business.Business>
    {
        IBusiness GetWithId(ObjectId id);
        IBusiness GetWithId(string id);
        IEnumerable<IBusinessHeadquaters> GetBusinessHeadquaters(ObjectId id);
        IEnumerable<string> GetBusinessMemberIds(ObjectId id);

        void Add(IBusiness business);
        void AddMember(string member, ObjectId businessId);
        void AddManyMembers(IEnumerable<string> members, ObjectId businessId);
        void AddHeadquaters(IBusinessHeadquaters headquaters, ObjectId businessId);
        void AddManyHeadquaters(IEnumerable<IBusinessHeadquaters> headquaters, ObjectId businessId);

        bool HasUniqueName(string name);
        bool HasUniqueTaxNumber(string taxNumber);
    }
}
