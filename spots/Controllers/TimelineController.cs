using System.Web.Mvc;
using spots.Modules.Timeline;
using spots.Modules.Timeline.Interfaces;
using spots.Services.ViewServices;

namespace spots.Controllers
{
    [Authorize]
    public class TimelineController : Controller
    {
        private readonly ITimeline _timeline;

        public TimelineController(ITimeline timeline)
        {
            _timeline = timeline;
        }

        // GET: Timeline
        public ActionResult Index()
        {
            ViewData[ViewDataAttributes.TimelineType] = TimelineTypes.Global;

            var posts = _timeline.GetTimeLineEvents(0);
            return View("Index", posts);
        }

        public ActionResult UserTimeline(string id)
        {
            ViewData[ViewDataAttributes.TimelineType] = TimelineTypes.User;
            return PartialView("_TimelinePartial");
        }

        // GET: Timeline/GetTimeLineEvetns
        public PartialViewResult GetTimeLineEvetns(int skip)
        {
            var posts = _timeline.GetTimeLineEvents(skip);
            return PartialView("_TimelineEventPosts", posts);
        }

        // GET: Timeline/GetPastTimeLineEvetns
        public PartialViewResult GetPastTimeLineEvetns(int skip)
        {
            var posts = _timeline.GetPastTimeLineEvents(skip);
            return PartialView("_TimelineEventPosts", posts);
        }

        //GET: Timeline/GetUserTimelineEvents
        public PartialViewResult GetUserTimelineEvents(int skip, string id)
        {
            var posts = _timeline.GetUserTimelineEvents(skip, id);
            return PartialView("_TimelineEventPosts", posts);
        }

        //GET: Timeline/GetPastUserTimelineEvents
        public PartialViewResult GetPastUserTimelineEvents(int skip, string id)
        {
            var posts = _timeline.GetPastUserTimelineEvents(skip, id);
            return PartialView("_TimelineEventPosts", posts);
        }
    }
}