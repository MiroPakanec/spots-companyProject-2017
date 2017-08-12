using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.BL.Core.Interfaces;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Spot;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Business.Interfaces;
using spots.Models.Response.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Models.Spot.ViewModels;
using spots.Models.User.Interfaces;

namespace spots.BL.Facades
{
    public class SpotFacade: ISpotFacade
    {
        private readonly ISpotCore _spotCore;
        private readonly ISpotResponse _response;
        private readonly IAtomicSpotWork _spotWork;
        private readonly ISpotRepository _spotRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly ISpotUserRepository _spotUserRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IExceptionLogFacade _exceptionLogFacade;

        public SpotFacade(ISpotCore spotCore, ISpotResponse response, IAtomicSpotWork spotWork, ISpotRepository spotRepository, IBusinessRepository businessRepository,
            ISpotUserRepository spotUserRepository, ILocationRepository locationRepository, IExceptionLogFacade exceptionLogFacade)
        {
            _spotCore = spotCore;
            _response = response;
            _spotWork = spotWork;
            _spotRepository = spotRepository;
            _businessRepository = businessRepository;
            _spotUserRepository = spotUserRepository;
            _locationRepository = locationRepository;
            _exceptionLogFacade = exceptionLogFacade;
        }

        public IEnumerable<IAvailableSpot> GetAvailableSpotsInCity(string city, BsonDateTime starDateTime, BsonDateTime endDateTime)
        {
            return _spotCore.GetAvailableSpotsInCity(city,starDateTime,endDateTime);
        }

        public ISpot GetSpotDetails(string id)
        {
            try
            {
                var spot = _spotRepository.GetWithId(id);
                var isVisible = _spotCore.IsSpotVisible(spot);

                if (isVisible)
                {
                    return spot;
                }

                var location = _locationRepository.GetWithId(spot.LocationId);
                var business = _businessRepository.GetWithId(location.BusinessId);
                var user = _spotUserRepository.GetCurrent;

                var isUserBusinessMember = _spotCore.IsUserBusinessMember(user.Email, business);
                if (isUserBusinessMember == false) return null;

                var canView = _spotCore.CanUserViewSpot(user, business);
                return canView ? spot : null;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public CreateSpotViewModel GetCreateSpotViewModel(string locationId)
        {
            var businessId = _locationRepository.GetWithId(locationId).MongoBusinessId;

            if (businessId == null)
            {
                throw new NullReferenceException("There is no business assosiated with location id - " + locationId);
            }

            return new CreateSpotViewModel
            {
                LocationId = locationId,
                BusinessId = businessId
            };
        }

        public AvailableHoursTimeIntervalViewModel SetAvailableHoursInterval(AvailableHoursTimeIntervalViewModel viewmodel)
        {
            if (viewmodel.Id.IsNullOrEmpty())
            {
                throw new ArgumentNullException($"Unable to get interval, because day or id were nto specified.");
            }

            var date = DateTime.Now;
            if (DateTime.TryParse(viewmodel.StartDate, out date))
            {
                viewmodel.StartDate = "";
            }

            if (DateTime.TryParse(viewmodel.EndDate, out date))
            {
                viewmodel.EndDate = "";
            }

            return viewmodel;
        }

        public string GetAvailableHoursButtonId(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"Unable to get interval, because day or id were nto specified.");
            }

            return "btn-" + id;
        }

        public bool HasBuiness(string email)
        {
            var businesses = _spotUserRepository.GetUserBusinesses(email);
            return businesses.IsNullOrEmpty() == false;
        }

        public IEnumerable<IUserBusiness> GetBusinesses(string email)
        {
            return _spotUserRepository.GetUserBusinesses(email);
        }

        public IEnumerable<IBusinessHeadquaters> GetLocations(string locationId)
        {
            return _businessRepository.GetBusinessHeadquaters(ObjectId.Parse(locationId));
        }

        public IResponse GetCreateSpotResponse(ISpot model)
        {
            try
            {
                model.Id = ObjectId.GenerateNewId();
                _spotWork.Add(model);

                _response.HasSucceeded("Spot was created successfully.");
                return _response;
            }
            catch
            {
                _response.HasFailed("We apologize, spot could not be created.");
                return _response;
            }
        }

        public IResponse GetCreateSpotInvalidModelResponse()
        {
            _response.HasFailed("Please check if you entered valid information.");
            return _response;
        }
    }
}
