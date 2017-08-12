using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Location.Interfaces;

namespace spots.BL.Facades.Interfaces
{
    public interface ILocationFacade
    {
        ILocation GetLocationWithId(string id);
    }
}
