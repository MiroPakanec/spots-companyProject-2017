using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Group;
using spots.Models.Authorisation.Actions;
using spots.Models.Authorisation.Roles;
using spots.Models.Authorisation.Roles.Interfaces;
using spots.Models.Business.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.Models.Group
{
    public class Group : IGroup
    {
        private readonly IMongoContextGeneric<Group> _context;

        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ObjectId> Events { get; set; }
        public IEnumerable<string> Members { get; set; }
        public IEnumerable<GroupRole> Roles { get; set; }

        public IGroupRepository Repository => new GroupRepository(_context);

        public Group() { }

        public Group(IMongoContextGeneric<Group> context)
        {
            _context = context;
        }

        public IGroup CreateDefaultUserGroup(ISpotUser user)
        {
            var members = new List<string>
            {
                user.Email
            };

            Id = ObjectId.GenerateNewId();
            Name = "Friends";
            Description = $"{user.FirstName}'s friends";
            Members = members;
            Events = new List<ObjectId>();

            return this;
        }

        public IGroup CreateDefaultBusinessGroup(IBusiness business)
        {
            Id = ObjectId.GenerateNewId();
            Name = $"{business.Name} group";
            Description = "";
            Members = business.Members;
            Events = new List<ObjectId>();

            return this;
        }
    }
}