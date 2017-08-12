using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using spots.DAL.Mongo.Context.Interfaces;
using spots.DAL.Queries.Repositories.Feedback;
using spots.Models.Feedback.Interfaces;


namespace spots.Models.Feedback
{
    public class Feedback: IFeedback
    {
        private readonly IMongoContextGeneric<Feedback> _context;

        public ObjectId Id { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool AnonymousBox { get; set; }
        public string CurrentPage { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }

        public IFeedbackRepository Repository => new FeedbackRepository(_context);

        public Feedback() { }
        
        public Feedback(IMongoContextGeneric<Feedback> context)
        {
            _context = context;
        }
        
    }
}