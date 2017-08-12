using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Collections;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Group.Interfaces;

namespace spots.DAL.Queries.Repositories.Group
{
    public class GroupRepository : Repository<Models.Group.Group>, IGroupRepository
    {
        public GroupRepository(IMongoContextGeneric<Models.Group.Group> mongoContext) 
            : base(mongoContext)
        {
        }

        public void Add(IGroup group)
        {
            MongoContext.Collection.InsertOne(group as Models.Group.Group);
        }

        public void AddMember(string email, ObjectId groupId)
        {
            var filter = Builders<Models.Group.Group>.Filter.Where(g => g.Id == groupId);
            var update = Builders<Models.Group.Group>.Update.Push(GroupCollections.Members, email);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void RemoveMember(string email, ObjectId groupId)
        {
            var filter = Builders<Models.Group.Group>.Filter.Where(g => g.Id == groupId);
            var update = Builders<Models.Group.Group>.Update.Pull(GroupCollections.Members, email);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public IGroup GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(g => g.Id == id).First();
        }

        public bool IsMember(string email, ObjectId groupId)
        {
            return MongoContext.Collection.Find(g => g.Id == groupId).First().Members.Any(m => m == email);
        }
    }
}