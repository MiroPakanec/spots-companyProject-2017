using spots.Models.Event.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Services.DateService;

namespace spots.Models.Business.ViewModels
{
    public class BusinessFeatureEventViewModel
    {
        public string MongoId { get; set; }
        public string Title { get; set; }
        public string StartTime { get; set; }

        public string FullAddress { get; set; }

        public string SpotId { get; set; }
        public string SpotName { get; set; }
        public int Invited { get; set; }

        public BusinessFeatureEventViewModel(){ }

        public BusinessFeatureEventViewModel(IEvent @event, ILocation location, ISpot spot)
        {
            MongoId = @event.MongoId;
            Title = @event.Title;
            StartTime = @event.StartDateTime.ToLocalTime().ToString(DateService.GetBasicDateTimeFormat);
            FullAddress = location.FullAddress;
            SpotId = spot.MongoId;
            SpotName = spot.Name;
            Invited = @event.Invited.Count;
        }
    }
}