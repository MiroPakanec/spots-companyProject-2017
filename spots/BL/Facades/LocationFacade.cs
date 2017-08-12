using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using spots.BL.Core.Interfaces;
using spots.BL.Facades.Interfaces;
using spots.DAL.Queries.Repositories.Location;
using spots.Models.Location.Interfaces;

namespace spots.BL.Facades
{
    public class LocationFacade: ILocationFacade
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ISpotCore _spotCore;
           
        public LocationFacade(ILocationRepository locationRepository, ISpotCore spotCore)
        {
            _locationRepository = locationRepository;
            _spotCore = spotCore;
        }

        public ILocation GetLocationWithId(string id)
        {
            var location = _locationRepository.GetWithId(ObjectId.Parse(id));
            
            location.Spots =_spotCore.SpotsIdsWithLocation(location) as IList<ObjectId>;
            return location;
        }
    }
}