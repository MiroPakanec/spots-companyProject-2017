using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using spots.Models.User.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace spots.Models.User.ViewModels
{
    public class UserCreateEventViewModel
    {
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserCreateEventViewModel Build(ISpotUser user)
        {
            var viewModel = new UserCreateEventViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,

            };

            return viewModel;
        }
    }
}