//using System.Security.Principal;
//using System.Web;
//using System.Web.Mvc;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using Moq;
//using NUnit.Framework;
//using spots.Models.Account.Interfaces;
//using spots.Models.User;
//using spots.Models.User.Extensions;
//using spots.Models.User.Interfaces;
//using spots.Models.User.ViewModels;
//using spots.Services.EmailService.Interfaces;
//using spotsTests.Controller.Extensions;
//using spotsTests.Model.Account.Extensions;
//using spotsTests.Model.User.Extensions;

//namespace spotsTests.Controller.UserController
//{
//    [TestFixture]
//    internal class UserController_uTests
//    {
//        private spots.Controllers.UserController _sut;

//        [SetUp]
//        public void SetUp()
//        {

//        }

//        [TearDown]
//        public void TearDown()
//        {
//            _sut = null;
//        }

//        /// <summary>
//        /// Test that User is redirected to my profile page if he is authentivaded.
//        /// </summary>
//        /// Result type - HappyPath
//        [Test]
//        public void IndexGet_UserController_HappyPath()
//        {
//            //Arrange
//            var user = new Mock<ISpotUser>();
//            var account = new Mock<IDelete>();
//            var response = new Mock<IUserResponse>();
//            var emailService = new Mock<IEmailService>();

//            _sut = new spots.Controllers.UserController(user.Object, account.Object, response.Object,
//                emailService.Object);

//            //Act
//            var result = _sut.Index() as RedirectToRouteResult;
//            Assert.IsNotNull(result);

//            var controller = result.RouteValues["controller"];
//            var action = result.RouteValues["action"];
//            var id = result.RouteValues["id"];

//            //Assert
//            Assert.AreEqual("User", controller);
//            Assert.AreEqual("Details", action);
//            Assert.AreEqual("MyProfile", id);
//        }

//        /// <summary>
//        /// Test that Logged in user profile is called when MyProfile is supplied as id parameter.
//        /// </summary>
//        /// Result type - HappyPath
//        [Test]
//        public void Details_UserController_LoggedInUserDetailesAreLoadedWithMyProfileId_HappyPath()
//        {
//            //Arrange
//            const string userId = "MyProfile";
//            const string email = "testmail@mail.com";

//            var newUserMock = new Mock<ISpotUser>()
//                .WithEmail(email);

//            var userMock = new Mock<ISpotUser>()
//                .WithRepositoryUser(newUserMock.Object);

//            var account = new Mock<IDelete>();
//            var response = new Mock<IUserResponse>();
//            var emailService = new Mock<IEmailService>();

//            var useridentityMock = new Mock<IPrincipal>()
//                .IsAuthenticated()
//                .WithIdentityName(email);

//            var httpContextMock = new Mock<HttpContextBase>().WithUserIdentity(useridentityMock.Object);
//            var controllerContextMock = new Mock<ControllerContext>().WithHttpContextBase(httpContextMock.Object);

//            _sut = new spots.Controllers.UserController(userMock.Object, account.Object, response.Object,
//                emailService.Object) {ControllerContext = controllerContextMock.Object};

//            //Act
//            var result = _sut.Details(userId) as ViewResult;

//            //Assert
//            userMock.Verify(m => m.Repository.GetWithEmail(email), Times.Once);
//            userMock.Verify(m => m.Repository.GetWithId(It.IsAny<ObjectId>()), Times.Never);
//            Assert.IsNotNull(result);

//            var resultModel = result.Model as ISpotUser;
//            Assert.IsNotNull(resultModel);
//            Assert.AreEqual(email, resultModel.Email);
//        }

//        /// <summary>
//        /// Test that Logged in users profile is loaded when empty string is supplied as Id parameter.
//        /// </summary>
//        /// Result type - HappyPath
//        [Test]
//        public void Details_UserController_LoggedInUserDetailesAreLoadedWithEmptyId_HappyPath()
//        {
//            //Arrange
//            var userId = string.Empty;
//            const string email = "testmail@mail.com";

//            var newUserMock = new Mock<ISpotUser>()
//                .WithEmail(email);

//            var userMock = new Mock<ISpotUser>()
//                .WithRepositoryUser(newUserMock.Object);
            
//            var account = new Mock<IDelete>();
//            var response = new Mock<IUserResponse>();
//            var emailService = new Mock<IEmailService>();

//            var useridentityMock = new Mock<IPrincipal>()
//                .IsAuthenticated()
//                .WithIdentityName(email);

//            var httpContextMock = new Mock<HttpContextBase>().WithUserIdentity(useridentityMock.Object);
//            var controllerContextMock = new Mock<ControllerContext>().WithHttpContextBase(httpContextMock.Object);

//            _sut = new spots.Controllers.UserController(userMock.Object, account.Object, response.Object,
//                emailService.Object) {ControllerContext = controllerContextMock.Object};

//            //Act
//            var result = _sut.Details(userId) as ViewResult;

//            //Assert
//            userMock.Verify(m => m.Repository.GetWithEmail(email), Times.Once);
//            userMock.Verify(m => m.Repository.GetWithId(It.IsAny<ObjectId>()), Times.Never);
//            Assert.IsNotNull(result);

//            var resultModel = result.Model as ISpotUser;
//            Assert.IsNotNull(resultModel);
//            Assert.AreEqual(email, resultModel.Email);
//        }

//        /// <summary>
//        /// Test that Another user profile page is loaded when different Id is sipplied.
//        /// </summary>
//        /// Result type - HappyPath
//        [Test]
//        public void Details_UserController_OtherUsersProfilePageIsLoadedBasedOnHisId_HappyPath()
//        {
//            //Arrange
//            var userObjectId = ObjectId.GenerateNewId();
//            var userId = userObjectId.ToString();
//            const string email = "testmail@mail.com";
//            const string requestedUserEmail = "anothermail@mail.com";

//            var newUserMock = new Mock<ISpotUser>()
//                .WithId(userObjectId)
//                .WithEmail(requestedUserEmail);

//            var userMock = new Mock<ISpotUser>()
//                .WithRepositoryUser(newUserMock.Object);

//            var account = new Mock<IDelete>();
//            var response = new Mock<IUserResponse>();
//            var emailService = new Mock<IEmailService>();

//            var useridentityMock = new Mock<IPrincipal>()
//                .IsAuthenticated()
//                .WithIdentityName(email);

//            var httpContextMock = new Mock<HttpContextBase>().WithUserIdentity(useridentityMock.Object);
//            var controllerContextMock = new Mock<ControllerContext>().WithHttpContextBase(httpContextMock.Object);

//            _sut = new spots.Controllers.UserController(userMock.Object, account.Object, response.Object,
//                emailService.Object) {ControllerContext = controllerContextMock.Object};

//            //Act
//            var result = _sut.Details(userId) as ViewResult;

//            //Assert
//            userMock.Verify(m => m.Repository.GetWithEmail(email), Times.Never);
//            userMock.Verify(m => m.Repository.GetWithId(userObjectId), Times.Once);
//            Assert.IsNotNull(result);

//            var resultModel = result.Model as ISpotUser;
//            Assert.IsNotNull(resultModel);
//            Assert.AreEqual(requestedUserEmail, resultModel.Email);
//            Assert.AreEqual(userObjectId, resultModel.Id);
//        }

//        /// <summary>
//        /// Test that user profile can be updated.
//        /// </summary>
//        [Test]
//        public void DetailsUpdate_UserController_UpdateUserProfile_HappyPath()
//        {
//            //Arrange
//            const string email = "testmail@mail.com";
//            const string responseText = "Update successfull";

//            var userMock = new Mock<ISpotUser>();
//            var accountMock = new Mock<IDelete>();
//            var responseMock = new Mock<IUserResponse>()
//                .WithSuccess()
//                .WithResponseText(responseText);

//            var emailServiceMock = new Mock<IEmailService>();

//            var useridentityMock = new Mock<IPrincipal>()
//                .IsAuthenticated()
//                .WithIdentityName(email);

//            var httpContextMock = new Mock<HttpContextBase>().WithUserIdentity(useridentityMock.Object);
//            var controllerContextMock = new Mock<ControllerContext>().WithHttpContextBase(httpContextMock.Object);

//            _sut = new spots.Controllers.UserController(
//                userMock.Object,
//                accountMock.Object,
//                responseMock.Object,
//                emailServiceMock.Object) {ControllerContext = controllerContextMock.Object};


//            var newUser = new UserPersonalViewModel() {Email = email};

//            //Act
//            var result = _sut.PersonalDetailsUpdate(newUser);

//            //Assert
//            responseMock.Verify(m => m.IdentifyUpdateResult(It.IsAny<ReplaceOneResult>()), Times.Once);
//            responseMock.Verify(m => m.HasFailed(It.IsAny<string>()), Times.Never);

//            Assert.IsNotNull(result);

//            var resultModel = result.Model as IUserResponse;
//            Assert.IsNotNull(resultModel);
//            Assert.AreEqual(true, resultModel.Success);
//            Assert.AreEqual(responseText, resultModel.ResponseText);
//        }
//    }
//}
