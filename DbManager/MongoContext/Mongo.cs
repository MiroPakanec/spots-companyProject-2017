using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbManager.Collections;
using MongoDB.Driver;
using spots.Models.User;

namespace DbManager.MongoContext
{
    internal static class Mongo
    {
        internal static bool DelteAll()
        {
            try
            {
                var context = new spots.DAL.Mongo.Context.MongoContext();

                context.SpotUsers.DeleteMany(c => true);
                context.Businesses.DeleteMany(c => true);
                context.Events.DeleteMany(c => true);
                context.Locations.DeleteMany(c => true);
                context.Spots.DeleteMany(c => true);
                context.Groups.DeleteMany(c => true);

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static bool PopulateDefault()
        {
            var context = new spots.DAL.Mongo.Context.MongoContext();

            context.SpotUsers.InsertMany(UserCollection.Users);
            context.Businesses.InsertMany(BusinessCollection.Businesses);
            context.Locations.InsertMany(LocationCollection.Locations);
            context.Spots.InsertMany(SpotsCollection.Spots);
            context.Groups.InsertMany(GroupCollection.Groups);
            context.Events.InsertMany(EventCollection.Events);

            return true;
        }
    }
}
