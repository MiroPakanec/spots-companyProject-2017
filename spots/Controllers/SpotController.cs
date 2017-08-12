using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Core.Internal;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Spot;
using spots.Models.Location;
using spots.Models.Location.Interfaces;
using spots.Models.Spot;
using spots.Models.Spot.Interfaces;
using spots.Models.Spot.ViewModels;
using spots.Models.User.Interfaces;
using spots.Models.Business.Interfaces;
using spots.Models.Response.Interfaces;
using spots.Models.Shared;
using spots.Models.User;

namespace spots.Controllers
{
    public class SpotController : Controller
    {
        private readonly ISpotFacade _spotFacade;

        public SpotController(ISpotFacade spotFacade)
        {
            _spotFacade = spotFacade;
        }

        // GET: Spot
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Spot/Details/5
        public ActionResult Details(string id)
        {
            var model = _spotFacade.GetSpotDetails(id);

            if (model == null)
            {
                return Content("You have no access to this page.");
            }

            return View(model as Spot);
        }

        // GET: Spot/Create
        public ActionResult Create(string locationId)
        {
            if (_spotFacade.HasBuiness(User.Identity.Name) == false)
            {
                return Content("If you want to create a spot, you have to create a business first.");
            }

            if (locationId.IsNullOrEmpty())
            {
                return View();
            }

            var viewModel = _spotFacade.GetCreateSpotViewModel(locationId);
            return View(viewModel);
        }

        // POST: Spot/Create
        [HttpPost]
        public PartialViewResult Create(Spot model)
        {
            IResponse response;

            if (ModelState.IsValid == false || model.HasValidAvailableHours == false)
            {
                response = _spotFacade.GetCreateSpotInvalidModelResponse();
                return PartialView("Create/_CreateResponsePartial", response as SpotResponse);
            }

            response = _spotFacade.GetCreateSpotResponse(model);
            return PartialView("Create/_CreateResponsePartial", response as SpotResponse);
        }

        //Post: /Spot/GetBusinesses
        [HttpPost]
        public PartialViewResult GetBusinesses()
        {
            var collection = _spotFacade.GetBusinesses(User.Identity.Name);
            return PartialView("Create/_BusinessDropdownPartial", collection);
        }

        //Post: /Spot/GetLocations
        [HttpPost]
        public PartialViewResult GetLocations(string id)
        {
            var collections = _spotFacade.GetLocations(id);
            return PartialView("Create/_LocationDropdownPartial", collections);
        }

        //Post: /Spot/AvailableHoursInterval
        [HttpPost]
        public PartialViewResult AvailableHoursInterval(AvailableHoursTimeIntervalViewModel viewmodel)
        {
            viewmodel = _spotFacade.SetAvailableHoursInterval(viewmodel);
            return PartialView("Create/_AvailableHoursIntervalPartial", viewmodel);
        }

        // GET: /Spot/AvailableHoursIntervalWarning
        public PartialViewResult AvailableHoursIntervalWarning()
        {
            return PartialView("Create/_AvailableHoursEmptyIntervalPartial");
        }
    }
}
