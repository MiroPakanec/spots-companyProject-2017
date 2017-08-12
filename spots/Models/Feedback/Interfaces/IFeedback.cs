using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using spots.DAL.Queries.Repositories.Feedback;

namespace spots.Models.Feedback.Interfaces
{
    public interface IFeedback
    {
         ObjectId Id { get; set; }
         string Message { get; set; }
         string Type { get; set; }
         bool AnonymousBox { get; set; }
         string CurrentPage { get; set; }
         string Email { get; set; }
         DateTime DateTime { get; set; }
         IFeedbackRepository Repository { get; }
    }
}
