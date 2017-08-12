//using System.Linq;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using spots.Models;
//using System.Web.Mvc;
//using System.Web.Routing;
//using MongoDB.Driver;
//using spots.Controllers;
//using spots.DAL.MongoDb;

//namespace spotsITests.Register
//{
//    [TestFixture]
//    class RegisterITests
//    {
//        private UserModel _userModel;
//        private readonly string _email = "test@email.com";
//        private readonly string _fname = "TestFname";
//        private readonly string _lname = "TestLname";
//        private readonly string _password = "TestPass123.";

//        [SetUp]
//        public void Setup()
//        {
//            DbContext.Manage.Users.DeleteMany(x => x.Email == _email);

//            _userModel = new UserModel{Email = _email, FirstName = _fname, LastName = _lname };
//        }

//        [TearDown]
//        public void TearDown()
//        {
//            DbContext.Manage.Users.DeleteMany(x => x.Email == _email);
//        }

//        /// <summary>
//        /// Test that Account controller Register POST method executes the right action with invalid modelstate.
//        /// </summary>
//        [Test]
//        public void InvalidModelState_AccountController_ExceptionalCase()
//        {
//            //Arrange
//            var sut = new AccountController();
//            sut.ModelState.AddModelError("test", "test");

//            //Act
//            var actionResult = sut.Register(new AccountViewModel()); 
//            var viewResult = actionResult.Result as ViewResult;

//            //Assert
//            Assert.IsNotNull(actionResult);
//            Assert.IsNotNull(viewResult);
//            Assert.AreEqual("Index", viewResult.ViewName);
//        }

//        /// <summary>
//        /// Test that inserts a user to mongo db and checks if was inserted properly.
//        /// </summary>
//        [Test]
//        public void InsertUserMongo_AccountController_HappyPath()
//        {
//            //Arrange
//            var config = new MongoConfig().WithLocalSettings();
//            var sut = new DbContext(config, MongoDatabases.MongoSpotsTest);

//            //Act
//            sut.Users.InsertOne(_userModel);

//            //Assert
//            Assert.IsTrue(sut.Users.AsQueryable().Any(x => x.Email == _email));
//        }
//    }
//}
