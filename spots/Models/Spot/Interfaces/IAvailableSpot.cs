namespace spots.Models.Spot.Interfaces
{
    public interface IAvailableSpot
    {
        string BusinessName { get; set; }
        string BusinessId { get; set; }
        string SpotName { get; set; }
        string SpotId { get; set; }
        int Capacity { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Zip { get; set; }
        string Country { get; set; }
    }
}
