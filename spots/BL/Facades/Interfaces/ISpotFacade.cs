using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Business.Interfaces;
using spots.Models.Response.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Models.Spot.ViewModels;
using spots.Models.User.Interfaces;

namespace spots.BL.Facades.Interfaces
{
    public interface ISpotFacade
    {
        IEnumerable<IAvailableSpot> GetAvailableSpotsInCity(string city, BsonDateTime starDateTime,
           BsonDateTime endDateTime);

        ISpot GetSpotDetails(string id);

        CreateSpotViewModel GetCreateSpotViewModel(string locationId);
        AvailableHoursTimeIntervalViewModel SetAvailableHoursInterval(AvailableHoursTimeIntervalViewModel viewmodel);

        bool HasBuiness(string email);
        IEnumerable<IUserBusiness> GetBusinesses(string email);
        IEnumerable<IBusinessHeadquaters> GetLocations(string locationId);

        IResponse GetCreateSpotResponse(ISpot model);
        IResponse GetCreateSpotInvalidModelResponse();
    }
}
