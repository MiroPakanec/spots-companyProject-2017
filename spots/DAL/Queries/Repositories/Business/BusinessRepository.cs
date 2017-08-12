using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Collections;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Business.Interfaces;

namespace spots.DAL.Queries.Repositories.Business
{
    public class BusinessRepository : Repository<Models.Business.Business>, IBusinessRepository
    {
        public BusinessRepository(IMongoContextGeneric<Models.Business.Business> mongoContext) 
            : base(mongoContext)
        {
        }

        public IBusiness GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(b => b.Id == id).First();
        }

        public IBusiness GetWithId(string id)
        {
            return MongoContext.Collection.Find(b => b.Id == ObjectId.Parse(id)).First();
        }

        public IEnumerable<IBusinessHeadquaters> GetBusinessHeadquaters(ObjectId id)
        {
            return MongoContext.Collection.Find(b => b.Id == id).First().Headquarters.ToList();
        }

        public IEnumerable<string> GetBusinessMemberIds(ObjectId id)
        {
            return MongoContext.Collection.Find(b => b.Id == id).First().Members.ToList();
        }

        public void Add(IBusiness business)
        {
            MongoContext.Collection.InsertOne(business as Models.Business.Business);
        }

        public void AddMember(string member, ObjectId businessId)
        {
            var filter = Builders<Models.Business.Business>.Filter.Where(b => b.Id == businessId);
            var update = Builders<Models.Business.Business>.Update.Push(BusinessCollections.Members, member);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddManyMembers(IEnumerable<string> members, ObjectId businessId)
        {
            foreach (var member in members)
            {
                var filter = Builders<Models.Business.Business>.Filter.Where(b => b.Id == businessId);
                var update = Builders<Models.Business.Business>.Update.Push(BusinessCollections.Members, member);

                MongoContext.Collection.UpdateOne(filter, update);
            }
        }

        public void AddHeadquaters(IBusinessHeadquaters headquaters, ObjectId businessId)
        {
            var filter = Builders<Models.Business.Business>.Filter.Where(b => b.Id == businessId);
            var update = Builders<Models.Business.Business>.Update.Push(BusinessCollections.Headquaters, headquaters);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddManyHeadquaters(IEnumerable<IBusinessHeadquaters> headquaters, ObjectId businessId)
        {
            foreach (var headquater in headquaters)
            {
                var filter = Builders<Models.Business.Business>.Filter.Where(b => b.Id == businessId);
                var update = Builders<Models.Business.Business>.Update.Push(BusinessCollections.Headquaters, headquater);

                MongoContext.Collection.UpdateOne(filter, update);
            }
        }

        public bool HasUniqueName(string name)
        {
            var exists = MongoContext.Collection.Find(b => b.Name.Equals(name)).Any();
            return !exists;
        }

        public bool HasUniqueTaxNumber(string taxNumber)
        {
            var exists = MongoContext.Collection.Find(b => b.TaxNumber.Equals(taxNumber)).Any();
            return !exists;
        }
    }
}