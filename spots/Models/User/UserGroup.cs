using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using spots.Models.User.Interfaces;

namespace spots.Models.User
{
    public class UserGroup : IUserGroup
    {
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }
        public string Role { get; set; }
    }
}