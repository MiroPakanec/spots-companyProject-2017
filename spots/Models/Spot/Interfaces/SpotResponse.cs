namespace spots.Models.Spot.Interfaces
{
    public class SpotResponse :Response.Response, ISpotResponse
    {
       

        public override string GetResponseDescription()
        {
            return "Spot response.";
        }

        
    }
}