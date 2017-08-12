using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using spots.Models;

namespace spotsTests.Model.Account
{
    [TestFixture]
    internal class AccountViewModelUTests
    {
        private AccountViewModel _sut;

        [SetUp]
        public void Setup()
        {
           _sut = new AccountViewModel();
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }

        /// <summary>
        /// Test that AccountViewModel is validated correctly.
        /// </summary>
        [Test]
        public void AccountViewModelValidation_Happypath()
        {
            
            var context = new ValidationContext(_sut, null, null);
            var results = new List<ValidationResult>();

            var isModelStateValid = Validator.TryValidateObject(_sut, context, results, true);

            Assert.IsTrue(isModelStateValid);
        }
    }
}
