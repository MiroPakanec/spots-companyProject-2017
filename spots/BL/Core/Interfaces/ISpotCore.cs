using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Business.Interfaces;
using spots.Models.Location.Interfaces;
using spots.Models.Spot.Interfaces;
using spots.Models.User.Interfaces;

namespace spots.BL.Core.Interfaces
{
    public interface ISpotCore
    {
        IEnumerable<IAvailableSpot> GetAvailableSpotsInCity(string city, BsonDateTime starDateTime,
            BsonDateTime endDateTime);

        IEnumerable<ObjectId> SpotsIdsWithLocation(ILocation location);

        IEnumerable<ISpot> GetSpotObjects(string city, BsonDateTime starDateTime,
            BsonDateTime endDateTime);

        bool IsSpotVisible(ISpot spot);
        bool IsUserBusinessMember(string email, IBusiness business);
        bool CanUserViewSpot(ISpotUser user, IBusiness business);
    }

}
