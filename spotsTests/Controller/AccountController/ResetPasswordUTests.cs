using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;

namespace spotsTests.Controller.AccountController
{
    internal class ResetPasswordUTests
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
        public void ResetPasswordGet_AccountController_ExceptionalCase()
        {
            //Arrange
            const string code = null;

            //Act
            var result = _sut.ResetPassword(code) as ViewResult;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.ViewName);
        }

        [Test]
        public void ResetPasswordGet_AccountController_HappyPath()
        {
            //Arrange
            const string code = "redundantCode";

            //Act
            var result = _sut.ResetPassword(code) as ViewResult;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void ResetPasswordConfirmationGet_AccountController_HappyPath()
        {
            //Arrange

            //Act
            var result = _sut.ResetPasswordConfirmation() as ViewResult;

            //Arrange
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }
    }
}
