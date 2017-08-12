using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using spots.Models.Account.Viewmodels;

namespace spotsTests.Model.Login
{
    [TestFixture]
    internal class LoginViewModelITests
    {

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// </summary>
        [Test]
        public void LoginViewModelValidation_Happypath()
        {
            var sut = new LoginViewModel()
            {
                Email = "miropkanec@gmail.com",
                Password = "ThisisPass1.",
                RememberMe = true
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsTrue(isModelStateValid);
        }

        /// <summary>
        /// Test that empty RegisterViewModel is validated correctly.
        /// </summary>
        [Test]
        public void LoginViewModelValidation_ExceptionalCase()
        {
            var sut = new LoginViewModel();
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }
    }
}
