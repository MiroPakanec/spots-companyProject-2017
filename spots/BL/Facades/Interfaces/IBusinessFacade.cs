using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Business.Interfaces;
using spots.Models.Business.ViewModels;
using spots.Models.User.Interfaces;

namespace spots.BL.Facades.Interfaces
{
    public interface IBusinessFacade
    {
        IEnumerable<ISpotUser> GetUsers(string partialEmail);
        IEnumerable<IBusinessHeadquaters> GetBusinessHeadquaters(string id);
        IEnumerable<BusinessFeatureEventViewModel> GetFeatureEvents(string businessId);

        BusinessDetailsViewModel GetBusinessDetailsViewModel(string id);

        bool HasUniqueName(string name);
        bool HasUniqueTaxNumber(string taxNumber);

        IBusinessResponse CreateBusinessResponse(CreateBusinessViewModel model, string createdBy);
        IBusinessResponse InvalidModelStateResponse { get; }
    }
}
