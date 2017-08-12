using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace spots.DAL.Mongo.Context
{
    public static class MongoDatabase
    {
        private const string Host = "localhost";
        internal const int Port = 27017;

        public static IMongoDatabase MainDatabase
        {
            get
            {
                try
                {
                    var server = new MongoServerAddress(Host, Port);
                    var settings = new MongoClientSettings { Server = server };
                    var client = new MongoClient(settings);
                    //return client.GetDatabase(MongoDatabases.MongoSpotsDevelopment);
                    return client.GetDatabase(MongoDatabases.MongoSpotsTest);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static IMongoDatabase AlphaTestDatabase
        {
            get
            {
                try
                {
                    var server = new MongoServerAddress(Host, Port);
                    var settings = new MongoClientSettings { Server = server };
                    var client = new MongoClient(settings);
                    return client.GetDatabase(MongoDatabases.MongoAlphaTest);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static IMongoDatabase SpotLogs
        {
            get
            {
                try
                {
                    var server = new MongoServerAddress(Host, Port);
                    var settings = new MongoClientSettings { Server = server };
                    var client = new MongoClient(settings);
                    return client.GetDatabase(MongoDatabases.SpotLogs);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}