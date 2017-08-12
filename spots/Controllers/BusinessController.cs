using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Core.Internal;
using spots.BL.Facades.Interfaces;
using spots.Models.Business.Interfaces;
using spots.Models.Business.ViewModels;
using spots.Models.User;
using spots.Services.Routing;

namespace spots.Controllers
{
    [Authorize]
    public class BusinessController : Controller
    {
        private readonly IBusinessFacade _facade;

        public BusinessController(IBusinessFacade facade)
        {
            _facade = facade;
        }

        // GET: Business
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Business/Details/5
        public ActionResult Details(string id)
        {
            var viewModel = _facade.GetBusinessDetailsViewModel(id);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Business/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Create(CreateBusinessViewModel model)
        {
            IBusinessResponse response;

            if (!ModelState.IsValid)
            {
                response = _facade.InvalidModelStateResponse;
                return PartialView("_CreateResponsePartial", response);
            }

            var identity = User.Identity.Name;
            response = _facade.CreateBusinessResponse(model, identity);

            return PartialView("_CreateResponsePartial", response);
        }

        //POST eamil, return list of users in json format
        [HttpPost]
        public PartialViewResult GetUsers(string id)
        {
            var email = EscapeHelper.UnescapeDots(id);

            var users = _facade.GetUsers(email);
            return PartialView("GetUsersSearchBox", users as IEnumerable<SpotUser>);
        }

        //GET: /Business/BusinessLocationsEnum
        public IEnumerable<IBusinessHeadquaters> BusinessLocationsEnum(string businessId)
        {
            return _facade.GetBusinessHeadquaters(businessId);
        }

        //GET: /Business/UpcomingEvents
        public PartialViewResult FeatureEvents(string id)
        {
            var viewModels = _facade.GetFeatureEvents(id);

            return viewModels.IsNullOrEmpty()
                ? PartialView("Details/_FeatureEventsEmptyPartial")
                : PartialView("Details/_FeatureEventsPartial", viewModels);
        }
    }
}
