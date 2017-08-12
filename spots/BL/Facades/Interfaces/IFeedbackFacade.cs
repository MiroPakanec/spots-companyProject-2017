using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using spots.Models.Feedback.Interfaces;
using spots.Models.Feedback.ViewModels;

namespace spots.BL.Facades.Interfaces
{
    public interface IFeedbackFacade
    {
         IFeedbackResponse Add(CreateFeedbackModelView feedbackModelView,string email);
         CreateFeedbackModelView CreateFeedbackModelView { get; }
        IFeedbackResponse InvalidModelStateResponse { get; }
    }
}
