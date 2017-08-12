using spots.Models.Feedback.Interfaces;

namespace spots.Models.Feedback
{
    public class FeedbackResponse : Response.Response, IFeedbackResponse
    {
        

        public override string GetResponseDescription()
        {
            return "Feedback response";
        }
    }
}