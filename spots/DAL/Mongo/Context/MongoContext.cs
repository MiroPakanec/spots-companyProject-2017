using MongoDB.Driver;
using spots.DAL.Mongo.Collections;
using spots.DAL.Mongo.Context.Interfaces;
using spots.Models.Business;
using spots.Models.Event;
using spots.Models.Feedback;
using spots.Models.Group;
using spots.Models.Location;
using spots.Models.Log;
using spots.Models.Spot;
using spots.Models.User;

namespace spots.DAL.Mongo.Context
{
    public class MongoContext : IMongoContext
    {
        public IMongoDatabase Database
        {
            get
            {
                try
                {
                    var server = new MongoServerAddress("localhost", 27017);
                    var settings = new MongoClientSettings { Server = server };
                    var client = new MongoClient(settings);
                    return client.GetDatabase(MongoDatabases.MongoSpotsDevelopment);
                }
                catch
                {
                    return null;
                }
            }
        }

        private static IMongoDatabase MainDatabase => MongoDatabase.MainDatabase;
        private static IMongoDatabase AlphaTestDatabase => MongoDatabase.AlphaTestDatabase;
        private static IMongoDatabase SpotLogs => MongoDatabase.SpotLogs;
        private static IMongoDatabase ExceptionLogging => MongoDatabase.SpotLogs;

        public IMongoCollection<SpotUser> SpotUsers => MainDatabase.GetCollection<SpotUser>(MongoCollections.Users);
        public IMongoCollection<Business> Businesses => MainDatabase.GetCollection<Business>(MongoCollections.Businesses);
        public IMongoCollection<Location> Locations => MainDatabase.GetCollection<Location>(MongoCollections.Locations);
        public IMongoCollection<Spot> Spots => MainDatabase.GetCollection<Spot>(MongoCollections.Spots);
        public IMongoCollection<Event> Events => MainDatabase.GetCollection<Event>(MongoCollections.Events);
        public IMongoCollection<Group> Groups => MainDatabase.GetCollection<Group>(MongoCollections.Groups);
        public IMongoCollection<Log> Logs => SpotLogs.GetCollection<Log>(MongoCollections.ActivityLog);
        public IMongoCollection<Feedback> Feedbacks => AlphaTestDatabase.GetCollection<Feedback>(MongoCollections.Feedbacks);

        public IMongoCollection<ExceptionLog> ExceptionLogs
            => ExceptionLogging.GetCollection<ExceptionLog>(MongoCollections.ExceptionLog);
    }
}