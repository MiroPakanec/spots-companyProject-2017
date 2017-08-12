using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.AtomicWork.Business;
using spots.Models.Authorisation.Roles;
using spots.Models.Business.Interfaces;
using spots.Models.Business.ViewModels;
using spots.Models.Event.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Location;
using spots.Models.Location.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.BL.Facades
{
    public class BusinessFacade : IBusinessFacade
    {
        private readonly IBusiness _business;
        private readonly IGroup _group;
        private readonly ILocation _location;
        private readonly ISpot _spot;
        private readonly ISpotUser _user;
        private readonly IEvent _event;
        private readonly IBusinessResponse _response;
        private readonly IAtomicBusinessWork _atomicWork;
        private readonly IExceptionLogFacade _exceptionLogFacade;

        public BusinessFacade(IBusiness business, IGroup group, ILocation location, ISpot spot, ISpotUser user,
            IEvent @event, IBusinessResponse response, IAtomicBusinessWork atomicBusinessWork, IExceptionLogFacade exceptionLogFacade)
        {
            _business = business;
            _group = group;
            _location = location;
            _spot = spot;
            _user = user;
            _event = @event;
            _response = response;
            _atomicWork = atomicBusinessWork;
            _exceptionLogFacade = exceptionLogFacade;
        }

        public IEnumerable<ISpotUser> GetUsers(string partialEmail)
        {
            try
            {
                return _user.Repository.GetAllWithPartialEmail(partialEmail);
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                return null;
            }
       
        }

        public IEnumerable<IBusinessHeadquaters> GetBusinessHeadquaters(string id)
        {
            try
            {
                var objectId = ObjectId.Parse(id);
                return _business.Repository.GetBusinessHeadquaters(objectId);
            }
            catch(Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                return null;
            }
          
        }

        public IEnumerable<BusinessFeatureEventViewModel> GetFeatureEvents(string businessId)
        {
            try
            {
                var events = _event.Repository.GetByBusiness(ObjectId.Parse(businessId));
                var viewModels = new List<BusinessFeatureEventViewModel>();

                foreach (var @event in events)
                {
                    var spot = _spot.Repository.GetWithId(@event.SpotId);
                    var location = _location.Repository.GetWithId(spot.LocationId);
                    var viewModel = new BusinessFeatureEventViewModel(@event, location, spot);

                    viewModels.Add(viewModel);
                }

                return viewModels;
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                return null;
            }
        }

        public BusinessDetailsViewModel GetBusinessDetailsViewModel(string id)
        {
            try
            {
                var business = _business.Repository.GetWithId(id);
                return new BusinessDetailsViewModel().SetFromBusiness(business);
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                return null;
            }
        }

        public bool HasUniqueName(string name)
        {
            try
            {
                return _business.Repository.HasUniqueName(name);
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                //not sure
                return false;
            }
        }

        public bool HasUniqueTaxNumber(string taxNumber)
        {
            try
            {
                return _business.Repository.HasUniqueTaxNumber(taxNumber);
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                //not sure
                return false;
            }
        }

        public IBusinessResponse CreateBusinessResponse(CreateBusinessViewModel model, string createdBy)
        {
            try
            {             
                if (HasUniqueName(model.Name) == false)
                {
                    _response.HasFailed("Business name already exists.");
                    return _response;
                }

                if (HasUniqueTaxNumber(model.TaxNumber) == false)
                {
                    _response.HasFailed("Business tax number already exists.");
                    return _response;
                }

                CreateBusiness(createdBy, model);

                _response.HasSucceeded("Business was created successfully.");
                return _response;
            }
            catch(Exception e)
            {
                _exceptionLogFacade.StoreException(e);
                _response.HasFailed("Business could not be created due to unexpected error, please try again later.");
                return _response;
            }
        }

        public IBusinessResponse InvalidModelStateResponse
        {
            get
            {
                try
                {
                    _response.HasFailed("Some of the information was not entered correctly.");
                    return _response;
                }
                catch (Exception e)
                {
                    _exceptionLogFacade.StoreException(e);
                    return null;
                }
            }
        }

        private void CreateBusiness(string createdBy, ICreateBusiness model)
        {
            try
            {
                model.CreatedBy = createdBy;

                var business = model.GetBusinessFromViewModel;
                var location = model.GetLocationFromViewModel;
                var userBusiness = _user.UserBusiness(business, location);
                var group = _group.CreateDefaultBusinessGroup(business);
                group.Roles = GroupRole.CreateDefault as IEnumerable<GroupRole>;

                business.Group = group.Id;
                _atomicWork.Add(business, location, userBusiness, group);
            }
            catch (Exception e)
            {
                _exceptionLogFacade.StoreException(e);
            }
        }
    }
}