using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Authorisation.Roles;
using spots.Models.Authorisation.Roles.Interfaces;
using spots.Models.Group;

namespace DbManager.Collections
{
    internal static class GroupCollection
    {
        public static string GID1 = "58e4c79fb7e8eb4cd082a71d";
        public static string GID2 = "58e4c79fb7e8eb4cd082a72c";

        public static string GID3 = "58e4c79fb7e8eb4cd082a72d";
        public static string GID4 = "58e4c79fb7e8eb4cd082a71e";
        public static string GID5 = "58e4c79fb7e8eb4cd082a72f";


        internal static IEnumerable<Group> Groups => new List<Group>
        {
            new Group
            {
                Id = ObjectId.Parse(GID1),
                Name = "Ucn group",
                Description = "Not specified.",
                Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>,
                Members = new List<string>
                {
                    UserCollection.UEmail1,
                    UserCollection.UEmail2
                },
                Events = new List<ObjectId>
                {
                    
                }
            },
            new Group
            {
                Id = ObjectId.Parse(GID2),
                Name = "My Restaurant group",
                Description = "Not specified.",
                Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>,
                Members = new List<string>
                {
                    UserCollection.UEmail2,
                    UserCollection.UEmail3
                },
                Events = new List<ObjectId>
                {

                }
            },
            new Group
            {
                Id = ObjectId.Parse(GID3),
                Name = "friends",
                Description = "Not specified.",
                Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>,
                Members = new List<string>
                {
                    UserCollection.UEmail1,
                },
                Events = new List<ObjectId>
                {

                }
            },
            new Group
            {
                Id = ObjectId.Parse(GID4),
                Name = "friends",
                Description = "Not specified.",
                Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>,
                Members = new List<string>
                {
                    UserCollection.UEmail2,
                },
                Events = new List<ObjectId>
                {

                }
            },
            new Group
            {
                Id = ObjectId.Parse(GID5),
                Name = "friends",
                Description = "Not specified.",
                Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>,
                Members = new List<string>
                {
                    UserCollection.UEmail3,
                },
                Events = new List<ObjectId>
                {

                }
            }
        };
    }
}
