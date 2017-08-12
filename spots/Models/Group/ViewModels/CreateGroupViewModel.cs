using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using spots.Models.Authorisation.Roles;
using spots.Models.Group.Interfaces;

namespace spots.Models.Group.ViewModels
{
    public class CreateGroupViewModel
    {
        [Required(ErrorMessage = "Please enter a group name.")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Z]{1,1}[a-zA-Z\s-._,\d]*[A-Za-z0-9]$", ErrorMessage = "Group name is invalid (e.g. University group - 1")]
        [DisplayName("Group name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a group description.")]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        [RegularExpression(@"[A-Za-z0-9]{1,1}[a-zA-Z\s-._,'’:-=-*/+\d]*[A-Za-z0-9.]$", ErrorMessage = "Group description is invalid.")]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public IEnumerable<string> Members { get; set; }

        public IGroup Group => new Group
        {
            Id = ObjectId.GenerateNewId(),
            Name = Name,
            Description = Description,
            Events = new List<ObjectId>(),
            Members = Members,
            Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>
        };
    }
}