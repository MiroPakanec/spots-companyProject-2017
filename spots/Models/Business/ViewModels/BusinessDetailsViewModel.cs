using System.Collections.Generic;
using MongoDB.Bson;
using spots.Models.Business.Extensions;
using spots.Models.Business.Interfaces;
using spots.Models.Event.ViewModels;

namespace spots.Models.Business.ViewModels
{
    public class BusinessDetailsViewModel
    {
        public ObjectId Id { get; set; }

        public string MongoId
        {
            get { return Id.ToString(); }
            set { Id = ObjectId.Parse(value); }
        }

        public string Name { get; set; }
        public string Occupation { get; set; }
        public string NumberOfEmployees { get; set; }
        public string Description { get; set; }

        public IEnumerable<BusinessHeadquaters> Headquarters { get; set; }

        public BusinessDetailsViewModel SetFromBusiness(IBusiness business)
        {
            Id = business.Id;
            Name = business.Name;
            Occupation = business.Occupation;
            NumberOfEmployees = business.Members.Count.RoundOffMessage();
            Description = business.Description;

            Headquarters = business.Headquarters;

            return this;
        }
    }
}