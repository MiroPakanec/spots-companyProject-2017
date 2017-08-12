using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Castle.Core.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.DAL.Mongo.Collections;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;

namespace spots.DAL.Queries.Repositories.SpotUser
{
    public class SpotUserRepository : Repository<Models.User.SpotUser>, ISpotUserRepository
    {
        public SpotUserRepository(IMongoContextGeneric<Models.User.SpotUser> mongoContext)  
            : base(mongoContext)
        {
        }

        public ISpotUser GetWithEmail(string email)
        {
            return MongoContext.Collection.Find(u => u.Email == email).First();
        }

        public ISpotUser GetWithId(ObjectId id)
        {
            return MongoContext.Collection.Find(u => u.Id == id).First();
        }

        public ISpotUser GetWithId(string id)
        {
            return MongoContext.Collection.Find(u => u.Id == ObjectId.Parse(id)).First();
        }

        public IEnumerable<IUserBusiness> GetUserBusinesses(string email)
        {
            return MongoContext.Collection.Find(u => u.Email == email).First().MyBusinesses;
        }

        public IEnumerable<IUserEvent> GetUserEvents(string email)
        {
            return MongoContext.Collection.Find(u => u.Email == email).First().MyEvents;
        }

        public IEnumerable<ISpotUser> GetAllWithPartialEmail(string email)
        {
            return MongoContext.Collection.Find(u => u.Email.StartsWith(email)).ToList();
        }

        public IEnumerable<ISpotUser> GetAllExceptCurrent
        {
            get
            {
                return MongoContext.Collection.Find(u => u.Email != GetCurrent.Email).ToList();
            }
        }

        public ISpotUser GetCurrent
        {
            get
            {
                var email = HttpContext.Current.User.Identity.Name;
                return GetWithEmail(email);
            }
        }

        public ObjectId GetCurrentId => GetCurrent.Id;

        public void Update(ISpotUser user)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == user.Id);
            var update = Builders<Models.User.SpotUser>.Update
                .Set("FirstName", user.FirstName)
                .Set("MiddleName", user.MiddleName)
                .Set("LastName", user.LastName)
                .Set("Age", user.Age)
                .Set("Phone", user.Phone)
                .Set("City", user.City);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void Update(UserDetailsViewModel user)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == user.Id);
            var update = Builders<Models.User.SpotUser>.Update
                .Set("FirstName", user.FirstName)
                .Set("MiddleName", user.MiddleName)
                .Set("LastName", user.LastName)
                .Set("Age", user.Age)
                .Set("Phone", user.Phone)
                .Set("City", user.City);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void UpdatePersonal(UserPersonalViewModel user)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == user.Id);
            var update = Builders<Models.User.SpotUser>.Update
                .Set("FirstName", user.FirstName)
                .Set("MiddleName", user.MiddleName)
                .Set("LastName", user.LastName)
                .Set("Age", user.Age);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void UpdateContact(UserContactViewModel user)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == user.Id);
            var update = Builders<Models.User.SpotUser>.Update
                .Set("City", user.City)
                .Set("Phone", user.Phone);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddBusinessWithId(IUserBusiness userBusiness, ObjectId id)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == id);
            var update = Builders<Models.User.SpotUser>.Update.Push(SpotUserCollections.MyBusinesses, userBusiness);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddBusinessWithEmail(IUserBusiness userBusiness, string email)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Email == email);
            var update = Builders<Models.User.SpotUser>.Update.Push(SpotUserCollections.MyBusinesses, userBusiness);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddBusinessForManyWithEmail(IUserBusiness userBusiness, IList<string> userEmails)
        {
            userEmails.ForEach(email => AddBusinessWithEmail(userBusiness, email));
        }

        public void AddGroupWithEmail(IUserGroup userGroup, string email)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Email == email);
            var update = Builders<Models.User.SpotUser>.Update.Push(SpotUserCollections.MyGroups, userGroup);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddEventWithId(IUserEvent userEvent, ObjectId id)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == id);
            var update = Builders<Models.User.SpotUser>.Update.Push(SpotUserCollections.MyEvents, 
                userEvent);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddEventWithEmail(IUserEvent userEvent, string email)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Email == email);
            var update = Builders<Models.User.SpotUser>.Update.Push(SpotUserCollections.MyEvents,
                userEvent);

            MongoContext.Collection.UpdateOne(filter, update);
        }

        public void AddEventForMany(IUserEvent userEvent, IList<string> userIds)
        {
            userIds.ForEach(id => AddEventWithId(userEvent, ObjectId.Parse(id)));
        }

        public void AddEventForMany(IUserEvent userEvent, IList<ObjectId> userIds)
        {
            userIds.ForEach(id => AddEventWithId(userEvent, id));
        }

        public void AddEventForManyWithEmail(IUserEvent userEvent, IList<string> userEmails)
        {
            userEmails.ForEach(email => AddEventWithEmail(userEvent, email));
        }

        public async Task<ISpotUser> GetWithEmailAsync(string email)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Email == email);
            using (var cursor = await MongoContext.Collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    return batch.First();
                }
            }

            throw new NullReferenceException();
        }

        public async Task<ISpotUser> GetWithIdAsync(ObjectId id)
        {
            //TODO: THROWS EXCEPTION IF NULL
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == id);
            using (var cursor = await MongoContext.Collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    return batch.First();
                }
            }

            throw new NullReferenceException();
        }

        public async Task<ISpotUser> GetWithIdAsync(string id)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Id == ObjectId.Parse(id));
            using (var cursor = await MongoContext.Collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    return batch.First();
                }
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<IUserBusiness>> GetUserBusinessesAsync(string email)
        {
            var filter = Builders<Models.User.SpotUser>.Filter.Where(u => u.Email == email);
            using (var cursor = await MongoContext.Collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    return batch.First().MyBusinesses;
                }
            }

            throw new NullReferenceException();
        }
    }
}