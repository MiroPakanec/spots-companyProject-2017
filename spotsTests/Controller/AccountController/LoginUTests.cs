using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using spots.Models;

namespace spotsTests.Controller.AccountController
{
    [TestFixture]
    internal class LoginUTests
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

        [Test]
        public void IndexGet_AccountController_ReturnsAccountView()
        {
            //Arrange

            //Act
            var result = _sut.Index() as ViewResult;
            var model = result.Model as AccountViewModel;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual("login", model.Type);
        }

        [Test]
        public void LoginGet_AccountController_ReturnsAccountViewAsLogin()
        {
            //Arrange
            var returnUrl = "redundantURL";
            //Act
            var result = _sut.Login(returnUrl) as ViewResult;
            var model = result.Model as AccountViewModel;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("login", model.Type);
            Assert.AreEqual(returnUrl, result.ViewBag.ReturnUrl);
        }
    }
}
