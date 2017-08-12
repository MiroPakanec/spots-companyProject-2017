using System.Web.Mvc;
using spots.BL.Facades.Interfaces;

namespace spots.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarFacade _facade;

        public CalendarController(ICalendarFacade facade)
        {
            _facade = facade;
        }

        //GET: Calendar
        public ActionResult Index()
        {
            var viewModel = _facade.GetIndexViewModel();
            return View(viewModel);
        }

        //GET: Calendar/Date
        [HttpPost]
        public string Date(string month, string year, int increment)
        {
            return _facade.GetDate(month, year, increment);
        }

        //Post: Calendar/CalendarFeatureEvents
        [HttpPost]
        public PartialViewResult CalendarFeatureEvents(string date)
        {
            var collection = _facade.GetCalendarFeatureEvents(date);
            return PartialView("_CalendarFeatureEventsPartial", collection);
        }

        //Post: Calendar/EventDetails
        [HttpPost]
        public PartialViewResult EventDetails(string id)
        {
            var model = _facade.GetEventDetailsViewModel(id);
            return PartialView("_CalendarFeatureEventDetailsPartial", model);
        }

        //Post: Calendar/
        [HttpPost]
        public PartialViewResult CalendarResult(string dateString)
        {
            var collection = _facade.GetCalendarResult(dateString);
            return PartialView("_CalendarResultPartial", collection);
        }
    }
}