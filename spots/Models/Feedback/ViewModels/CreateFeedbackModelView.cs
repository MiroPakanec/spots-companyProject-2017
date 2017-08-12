using System.ComponentModel.DataAnnotations;

namespace spots.Models.Feedback.ViewModels
{
    public class CreateFeedbackModelView
    {
        [Required(ErrorMessage = "Please enter a Message")]
        public string Message { get; set; }
        public string Type { get; set; }
        public bool AnonymousBox { get; set; }
        public string CurrentPage { get; set; }
    }
}