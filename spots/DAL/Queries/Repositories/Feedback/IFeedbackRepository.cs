using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Feedback.Interfaces;

namespace spots.DAL.Queries.Repositories.Feedback
{
    public interface IFeedbackRepository
    {
        void Add(IFeedback feedback);
    }
}
