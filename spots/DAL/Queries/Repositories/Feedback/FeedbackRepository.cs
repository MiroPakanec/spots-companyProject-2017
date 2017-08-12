using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Core;
using spots.Models.Feedback.Interfaces;

namespace spots.DAL.Queries.Repositories.Feedback
{
    public class FeedbackRepository: Repository<Models.Feedback.Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IMongoContextGeneric<Models.Feedback.Feedback> mongoContext) : base(mongoContext)
        {
        }

        public void Add(IFeedback feedback)
        {
            MongoContext.Collection.InsertOne(feedback as Models.Feedback.Feedback);
        }
    }
}