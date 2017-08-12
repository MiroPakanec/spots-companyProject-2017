using System.Web.Mvc;
using spots.BL.Facades.Interfaces;
using spots.Models.Feedback.Interfaces;
using spots.Models.Feedback.ViewModels;

namespace spots.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackFacade _feedbackFacade;
        

        public FeedbackController(IFeedbackFacade feedbackFacade)
        {
           
            _feedbackFacade = feedbackFacade;   
        }
        // GET: Feedback/Create
        public ActionResult Create()
        {
            var viewModel = _feedbackFacade.CreateFeedbackModelView;  
            return PartialView("../Shared/_FeedbackPartial", viewModel);
        }

        // POST: Feedback/Create
        [HttpPost]
        public PartialViewResult Create(CreateFeedbackModelView createFeedbackModelView)
        {
            IFeedbackResponse response; 

            if (ModelState.IsValid == false)
            {
                response = _feedbackFacade.InvalidModelStateResponse;
                return PartialView("../Shared/_FeedbackCreateResponsePartial", response);
            }

            var email = User.Identity.Name;
            response = _feedbackFacade.Add(createFeedbackModelView, email);
            return PartialView("../Shared/_FeedbackCreateResponsePartial", response);

        }


    }
}