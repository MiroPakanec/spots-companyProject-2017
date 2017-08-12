using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.Models.Authorisation.Actions.Interfaces;

namespace spots.Models.Authorisation.Roles.Interfaces
{
    public interface IGroupRole
    {
        string Title { get; set; }
        IDictionary<string, bool> ActionDictionary { get; set; }
    }
}
