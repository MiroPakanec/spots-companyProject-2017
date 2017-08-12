using MongoDB.Driver;
using NUnit.Framework;
using spots.DAL.Mongo;
using spots.DAL.Mongo.Context;
using spots.DAL.Mongo.Context.Interfaces;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Database.Mongo.User
{
    public class User
    {
        private IMongoContext _context;
        private string _email;

        public User WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public IVerificationTestStep Exists
        {
            get
            {
                return new VerificationTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _context = new MongoContext();
                    var result = _context.SpotUsers.Find(u => u.Email == _email).Count();

                    Assert.That(result > 0, $"User with email {_email} could not be found in the Mongo database.");
                });
            }
        }

        public IActionTestStep Delete
        {
            get
            {
                return new ActionTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _context = new MongoContext();
                    _context.SpotUsers.DeleteMany(u => u.Email == _email);                   
                });
            }
        }

        public IVerificationTestStep WasDeleted
        {
            get
            {
                return new VerificationTestStep((driver) =>
                {
                    Assert.IsNotNull(_email, "User email has to be specified.");

                    _context = new MongoContext();
                    var result = _context.SpotUsers.Find(u => u.Email == _email).Count();

                    Assert.AreEqual(0, result, $"User with email {_email} was could not be deleted from the Mongodb during the test run.");
                });
            }
        }
    }
}
