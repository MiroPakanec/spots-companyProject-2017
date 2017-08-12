using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.Services.DateService;

namespace spots.Models.Event.ViewModels
{
    public class CreateEventViewModel
    {
        [Required]
        [DisplayName("City")]
        public string Location { get; set; }

        [Required]
        [DisplayName("Event Start")]
        public string StartDateTime { get; set; }

        [Required]
        [DisplayName("Event End")]
        public string EndDateTime { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Available to public")]
        public bool Availability { get; set; }

        [DisplayName("Visible to public")]
        public bool Visibility { get; set; }

        public string SpotId { get; set; }

        public string BusinessId { get; set; }

        public List<string> Invited { get; set; }

        public CreateEventViewModel()
        {
            if (Invited == null)
            {
                Invited = new List<string>();
            }
        }

        public bool IsValid => HasValidDates && HasValidSpotId;

        public bool HasValidDates
        {
            get
            {
                var startDate = DateService.ToBson(StartDateTime);
                var endDate = DateService.ToBson(EndDateTime);
                var now = DateService.GetCurrentBson;

                return startDate < endDate && startDate >= now && endDate >= now;
            }
        }

        public bool HasValidSpotId
        {
            get
            {
                ObjectId objectid;
                return !SpotId.IsNullOrEmpty() && ObjectId.TryParse(SpotId, out objectid);
            }
        }

        public bool HasValidInvitationSet
        {
            get
            {
                ObjectId objectid;
                var counter = Invited.Count(userId => !ObjectId.TryParse(userId, out objectid));
                return counter <= 0;
            }
        }

        public Event GetEventFromViewModel => new Event
        {
            Id = ObjectId.GenerateNewId(),
            Title = Title,
            Description = Description,
            StartDateTime = DateService.ToBson(StartDateTime),
            EndDateTime = DateService.ToBson(EndDateTime),
            SpotId = ObjectId.Parse(SpotId),
            BusinessId = ObjectId.Parse(BusinessId),
            City = Location,
            Availability = Availability,
            Visibility = Visibility,
            Invited = Invited
        };
    }
}