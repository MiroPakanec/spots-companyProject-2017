using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using MongoDB.Bson;
using spots.BL.Core.Interfaces;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.Repositories.Event;
using spots.Models.Event.ViewModels;
using spots.Models.Spot.ViewModels;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;
using spots.Services.DateService;

namespace spots.BL.Facades
{
    public class EventFacade : IEventFacade
    {
        private readonly IEventRepository _repository;
        private readonly ISpotUser _spotUser;
        private readonly IEventCore _eventCore;
        
        public EventFacade(IEventRepository repository, ISpotUser spotUser, IEventCore eventCore)
        {
            _repository = repository;
            _spotUser = spotUser;
            _eventCore = eventCore;
            
        }

        public IEnumerable<UserCreateEventViewModel> GetAllUserCreateEventViewModels()
        {
            var allUsers = _spotUser.Repository.GetAllExceptCurrent;
            var viewModels = new List<UserCreateEventViewModel>();

            foreach (var user in allUsers)
            {
                var viewModel = new UserCreateEventViewModel();
                viewModels.Add(viewModel.Build(user));
            }

            return viewModels;
        }

        public IEnumerable<CommonFreeTimesViewModel> GetBestCommonFreeTimesViewModels(
            CreateEventTimeSlotsViewModel commonFreeTimesViewModel)
        {
            var commonFreeTimes = _eventCore.GetCommonFreeTimes(commonFreeTimesViewModel);
            return commonFreeTimes;

        }

        public IEnumerable<string> GetPublicEventAddresses(string city, DateTime startDateTime, DateTime endDateTime)
        {
            startDateTime = DateTime.Now;
            endDateTime = DateTime.Now.AddDays(5);

            var spots = _repository.GetEventSpots(city, startDateTime, endDateTime);

            throw new NotImplementedException();
        }
    }
}