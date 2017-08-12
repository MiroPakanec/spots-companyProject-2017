using System.Web.Mvc;
using NUnit.Framework;
using spots.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace spotsTests.Controller.AccountController
{
    [TestFixture]
    internal class RegisterUTests
    {
        private spots.Controllers.AccountController _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new spots.Controllers.AccountController();
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }

        //[Test]
        //public void IndexrGet_AccountController_ReturnsAccountView()
        //{
        //    //Arrange

        //    //Act
        //    var result = _sut.Index() as ViewResult;
        //    var model = result.Model as AccountViewModel;

        //    //Arrange
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("", result.ViewName);
        //    Assert.AreEqual("register", model.Type);
        //}

        [Test]
        public void RegisterGet_AccountController_ReturnsAccountView()
        {
            //Arrange

            //Act
            var result = _sut.Register() as ViewResult;
            var model = result.Model as AccountViewModel;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("register", model.Type);
        }
    }
}
