using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.BL.Core.Interfaces;
using spots.DAL.Queries.Repositories.Business;
using spots.DAL.Queries.Repositories.Event;
using spots.DAL.Queries.Repositories.Group;
using spots.DAL.Queries.Repositories.Location;
using spots.DAL.Queries.Repositories.Spot;
using spots.DAL.Queries.Repositories.SpotUser;
using spots.Models.Business.Interfaces;
using spots.Models.Spot.Interfaces;

namespace spots.BL.Core
{
    public class BusinessCore : IBusinessCore
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IBusinessRepository _businessRepository;

        public BusinessCore(IBusinessRepository businessRepository,
            ILocationRepository locationRepository)
        {
            _businessRepository = businessRepository;
            _locationRepository = locationRepository;
        }

        public bool IsUserInBusiness(IBusiness business, string email)
        {
            return business.Members.Contains(email);
        }

        public IBusiness GetBusinessWithSpot(ISpot spot)
        {
            var location = _locationRepository.GetWithId(spot.LocationId);
            var business = _businessRepository.GetWithId(location.BusinessId);
            return business;
        }
    }
}