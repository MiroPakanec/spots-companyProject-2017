using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.Models.Authorisation.Actions.ViewModels;
using spots.Models.Authorisation.Roles.Interfaces;
using spots.Models.Group.Interfaces;

namespace spots.Models.Group.ViewModels
{
    public class GroupDetailsViewModel
    {
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<string> Members { get; set; }
        public IEnumerable<ObjectId> Events { get; set; }
        public IEnumerable<IGroupRole> Roles { get; set; }

        public GroupDetailsViewModel() { }

        public GroupDetailsViewModel(IGroup group)
        {
            Id = group.Id;
            Name = group.Name;
            Description = group.Description;
            Members = group.Members;
            Events = group.Events;
            Roles = group.Roles;
        }
    }
}