using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Core.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Event;
using spots.DAL.Queries.AtomicWork.Spot;
using spots.Models.Event;
using spots.Models.Event.Interfaces;
using spots.Models.Event.ViewModels;
using spots.Models.Spot;
using spots.Models.Spot.ViewModels;
using spots.Models.User.Interfaces;
using spots.Services.DateService;
using spots.Services.ViewServices;

namespace spots.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ISpotUser _user;
        private readonly IEventResponse _response;
        private readonly IAtomicSpotWork _atomicSpotWork;
        private readonly IAtomicEventWork _atomicEventWork;
        private readonly IEventFacade _eventFacade;
        private readonly ISpotFacade _spotFacade;

        public EventController(ISpotUser user, IEventResponse response, IAtomicSpotWork atomicSpotWork,
            IAtomicEventWork atomicEventWork, IEventFacade eventFacade, ISpotFacade spotFacade)
        {
            _user = user;
            _response = response;

            _atomicSpotWork = atomicSpotWork;
            _atomicEventWork = atomicEventWork;

            _eventFacade = eventFacade;
            _spotFacade = spotFacade;
        }

        // GET: Event
        public ActionResult Index()
        {
            return RedirectToAction("GetAvailableSpots");
        }

        // GET: Event/Details
        public ActionResult Details(string id)
        {
            var model = _atomicEventWork.GetEventDetails(id);
            return View("Details", model as EventDetailsViewModel);
        }

        // GET: /Event/GetAvailableSpots
        public ActionResult GetAvailableSpots()
        {
            return View();
        }

        // POST: /Event/GetAvailableSpots
        [HttpPost]
        public ActionResult GetAvailableSpots(CreateEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_SpotsNotAvailable");
            }

            var startDate = DateService.ToBson(model.StartDateTime);
            var endDate = DateService.ToBson(model.EndDateTime);
            
            var availableSpots = _spotFacade.GetAvailableSpotsInCity(model.Location, startDate, endDate);

            return availableSpots.IsNullOrEmpty()
                ? PartialView("_SpotsNotAvailable")
                : PartialView("_AvailableSpots", availableSpots as List<AvailableSpotsViewModel>);
        }

        [HttpPost]
        public ActionResult Create(CreateEventViewModel model)
        {
            try
            {
                var creator = _user.Repository.GetCurrentId.ToString();
                model.Invited.Add(creator);

                if (!ModelState.IsValid || !model.IsValid)
                {
                    _response.HasFailed("Entered information are not valid.");
                    return PartialView("_EventResponse", _response as EventResponse);
                }

                var anEvent = model.GetEventFromViewModel;
                var userEvent = _user.UserEvent(anEvent);
                
                _atomicEventWork.Add(anEvent, userEvent);

                return JavaScript(RedirectTo.Action(Url ,"Index", "Timeline"));
            }
            catch
            {
                _response.HasFailed("We apologize, an unexpected error has occured.");
                return PartialView("_EventResponse", _response as EventResponse);
            }
        }

        // GET: Event/Search
        public ViewResult Search()
        {
            var city = _user.Repository.GetCurrent.City;
            var date = DateTime.Now.ToString(DateService.GetBasicDateFormat);

            var model = new SearchEventsViewModel {City = city, Date = date};
            return View(model);
        }

        // POST: Event/Search
        [HttpPost]
        public ActionResult Search(SearchEventsViewModel model, int skip, string orderBy)
        {
            if (ModelState.IsValid == false || model.HasValidDate == false)
            {
                _response.HasFailed("Some information was not entered correcntly");
                return PartialView("_EventResponse", _response as EventResponse);
            }

            var bsonDate = DateService.ToBson(model.Date);
            var events = _atomicEventWork.SearchEvents(model.City, bsonDate, skip, orderBy);

            return events.IsNullOrEmpty()
                ? PartialView("Search/_EventsNotAvailable")
                : PartialView("Search/_EventSearchResponsePartial", events);
        }

        public ActionResult CreateEventTwo()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetCommonFreeTime(CreateEventTimeSlotsViewModel commonFreeTimesViewModel)
        {
            var bestCommonFreeTimes = _eventFacade.GetBestCommonFreeTimesViewModels(commonFreeTimesViewModel);
            return PartialView("CreateEventTwo/_CreateEventTimeCityPartialPage", bestCommonFreeTimes);
        }     
    }
}