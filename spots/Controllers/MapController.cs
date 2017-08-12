using System;
using System.Collections.Generic;
using System.Web.Mvc;
using spots.BL.Facades.Interfaces;
using spots.Modules.Map.Models;

namespace spots.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapFacade _facade;

        public MapController(IMapFacade facade)
        {
            _facade = facade;
        }

        // GET: Map
        public ActionResult Index()
        {
            return RedirectToAction("Details");
        }

        // GET: Map/Details
        public ActionResult Details()
        {
            return View();
        }

        // POST: /Map/Load
        [HttpPost]
        public PartialViewResult Load(MapFilter filter)
        {
            var viewmodel = _facade.GetMapDetailsViewModel(filter);
            return PartialView("_LoadPartial", viewmodel);
        }

        // POST: /Map/LoadEvents
        [HttpPost]
        public ActionResult LoadGeolocations(MapFilter filter)
        {
            var viewmodel = _facade.GetMapDetailsViewModel(filter);

            if (viewmodel != null)
            {
                return PartialView("_MapEventsPartial", viewmodel);
            }

            return Content("");
        }


        // GET: /Map/Load
        public PartialViewResult Load()
        {
            return PartialView("_MapPartial");
        }
    }
}