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
    internal class ForgotPassword
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
        public void ForgotPasswordGet_AccountController_ReturnsAccountView()
        {
            //Arrange

            //Act
            var result = _sut.ForgotPassword() as ViewResult;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ForgotPasswordConfirmationGet_AccountController_ReturnsAccountView()
        {
            //Arrange

            //Act
            var result = _sut.ForgotPasswordConfirmation() as ViewResult;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }
    }
}
