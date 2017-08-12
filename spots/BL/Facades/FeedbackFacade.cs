using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.BL.Facades.Interfaces;
using spots.Models.Feedback;
using spots.Models.Feedback.Interfaces;
using spots.Models.Feedback.ViewModels;

namespace spots.BL.Facades
{
    public class FeedbackFacade: IFeedbackFacade
    {
        private readonly IFeedback _feedback;
        private readonly IFeedbackResponse _response;

        public FeedbackFacade(IFeedback feedback, IFeedbackResponse response)
        {
            _feedback = feedback;
            _response = response;
        }
        public IFeedbackResponse Add(CreateFeedbackModelView feedbackModelView, string email)
        {
            try
            {
                if (feedbackModelView.AnonymousBox == true)
                {
                    email = null;
                }
                var feedback = new Feedback()
                {
                    AnonymousBox = feedbackModelView.AnonymousBox,
                    CurrentPage = feedbackModelView.CurrentPage,
                    DateTime = DateTime.Now,
                    Message = feedbackModelView.Message,
                    Type = feedbackModelView.Type,
                    Email = email
                };


                _feedback.Repository.Add(feedback);
                _response.HasSucceeded("The Feedback was created successfully.");
                return _response;
            }
            catch
            {
                _response.HasFailed("Feedback could not be created due to unexpected error, please try again later.");
                return _response;
            }

        }
        public IFeedbackResponse InvalidModelStateResponse
        {
            get
            {
                _response.HasFailed("Some of the information was not entered correctly.");
                return _response;
            }
        }
        public CreateFeedbackModelView CreateFeedbackModelView => new CreateFeedbackModelView();
    }
}