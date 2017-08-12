using System;
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
    public class MongoContextGeneric<TEntity> : IMongoContextGeneric<TEntity> where TEntity : class
    {
        private static IMongoDatabase MainDatabase => MongoDatabase.MainDatabase;
        private static IMongoDatabase AlphaTestDatabase => MongoDatabase.AlphaTestDatabase;
        private static IMongoDatabase SpotLogs => MongoDatabase.SpotLogs;

        public IMongoCollection<TEntity> Collection => GetCollectionWithType;

        private static IMongoCollection<TEntity> GetCollectionWithType
        {
            get
            {
                if (IsType(typeof(SpotUser)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Users);
                }

                if (IsType(typeof(Business)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Businesses);
                }

                if (IsType(typeof(Location)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Locations);
                }

                if (IsType(typeof(Spot)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Spots);
                }

                if (IsType(typeof(Event)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Events);
                }

                if (IsType(typeof(Group)))
                {
                    return MainDatabase.GetCollection<TEntity>(MongoCollections.Groups);
                }

                if (IsType(typeof(Feedback)))
                {
                    return AlphaTestDatabase.GetCollection<TEntity>(MongoCollections.Feedbacks);
                }

                if (IsType(typeof(Log)))
                {
                    return SpotLogs.GetCollection<TEntity>(MongoCollections.ActivityLog);
                }

                if (IsType(typeof(ExceptionLog)))
                {
                    return SpotLogs.GetCollection<TEntity>(MongoCollections.ExceptionLog);
                }

                throw new ArgumentException("Unknown database collection");
            }
        }

        private static bool IsType(Type type)
        {
            return typeof(TEntity).IsEquivalentTo(type);
        }
    }
}