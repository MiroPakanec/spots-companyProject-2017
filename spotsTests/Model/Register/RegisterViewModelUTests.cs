using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using spots.Models.Account.Viewmodels;

namespace spotsTests.Model.Register
{
    [TestFixture]
    internal class RegisterViewModelUTests
    {

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_Happypath()
        {
            var sut = new RegisterViewModel
            {
                Email = "miropkanec@gmail.com",
                FirstName = "Miroslav",
                LastName = "Pakanec",
                Password = "ThisisPass1.",
                ConfirmPassword = "ThisisPass1."
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsTrue(isModelStateValid);
        }

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// Insecure Password.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_ExceptionalCase_InsecurePassword()
        {
            var sut = new RegisterViewModel
            {
                Email = "miropkanec@gmail.com",
                FirstName = "Miroslav",
                LastName = "Pakanec",
                Password = "passw",
                ConfirmPassword = "passw"
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// Last name is too short.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_ExceptionalCase_LastNameTooShort()
        {
            var sut = new RegisterViewModel
            {
                Email = "miropkanec@gmail.com",
                FirstName = "Miroslav",
                LastName = "P",
                Password = "ThisisPass1.",
                ConfirmPassword = "ThisisPass1."
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// Last name contains digit.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_ExceptionalCase_LastNameContainsDigit()
        {
            var sut = new RegisterViewModel
            {
                Email = "miropkanec@gmail.com",
                FirstName = "Miroslav",
                LastName = "Pakanec1",
                Password = "ThisisPass1.",
                ConfirmPassword = "ThisisPass1."
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        /// <summary>
        /// Test that RegisterViewModel is validated correctly.
        /// Password does not match.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_ExceptionalCase_NotMatchingPassword()
        {
            var sut = new RegisterViewModel
            {
                Email = "miropkanec@gmail.com",
                FirstName = "Miroslav",
                LastName = "Pakanec",
                Password = "ThisisPass1.",
                ConfirmPassword = "ThisisPass2."
            };
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }

        /// <summary>
        /// Test that empty RegisterViewModel is validated correctly.
        /// </summary>
        [Test]
        public void RegisterViewModelValidation_ExceptionalCase()
        {
            var sut = new RegisterViewModel();
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);

            Assert.IsFalse(isModelStateValid);
        }
    }
}
