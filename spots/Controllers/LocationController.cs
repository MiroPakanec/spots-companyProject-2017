using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Location;
using spots.Models.Location;
using spots.Models.Location.Interfaces;
using spots.Models.Location.ViewModels;
using spots.Models.User.Interfaces;

namespace spots.Controllers
{
    public class LocationController : Controller
    {
        private readonly ISpotUser _user;
        private readonly ILocation _location;
        private readonly IAtomicLocationWork _atomicWork;
        private readonly ILocationResponse _response;
        private readonly ILocationFacade _locationFacade;

        public LocationController(ISpotUser user, ILocation location, IAtomicLocationWork atomicWork,
            ILocationResponse response, ILocationFacade locationFacade)
        {
            _user = user;
            _location = location;
            _atomicWork = atomicWork;
            _response = response;
            _locationFacade = locationFacade;
        }

        public ActionResult Index()
        {
            //TODO: Dropdown to select business will have to be added
            return RedirectToAction("Create");
        }

        // GET: Location/Details/5
        public ActionResult Details(string id)
        {
            var model = _locationFacade.GetLocationWithId(id);
            return View(model as Location);
        }

        // GET: Location/Create
        public ActionResult Create(string businessId)
        {
            var userBusinesses = _user.Repository.GetCurrent.MyBusinesses;

            if (userBusinesses.IsNullOrEmpty())
            {
                return Content("If you want to create a location, you have to create a business first.");
            }

            var model = new CreateLocationViewModel(userBusinesses, businessId);

            return View(model);
        }

        // POST: Location/Create
        [HttpPost]
        public PartialViewResult Create(CreateLocationViewModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    _response.HasFailed("Please check if you entered valid information.");
                    return PartialView("Create/_CreateResponsePartial", _response as LocationResponse);
                }

                model.LocationId = ObjectId.GenerateNewId();
                _atomicWork.Add(model);

                _response.HasSucceeded("Location was created successfully.");
                return PartialView("Create/_CreateResponsePartial", _response as LocationResponse);
            }
            catch
            {
                _response.HasFailed("We apologize, location could not be created.");
                return PartialView("Create/_CreateResponsePartial", _response as LocationResponse);
            }
        }

        //POST city, return list of cities in json format
        [HttpPost]
        public async Task<PartialViewResult> GetCities(string city)
        {
            var list = await _location.Repository.GetCitiesStartingWithAsync(city);
            return PartialView("_GetCitiesSearchBox", list as HashSet<string>);
        }
    }
}
