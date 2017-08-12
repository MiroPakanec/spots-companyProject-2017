using spots.Models.Spot.Interfaces;

namespace spots.Models.Spot.ViewModels
{
    public class AvailableSpotsViewModel : IAvailableSpot
    {
        public string BusinessName { get; set; }
        public string BusinessId { get; set; }
        public string SpotName { get; set; }
        public string SpotId { get; set; }
        public int Capacity { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}