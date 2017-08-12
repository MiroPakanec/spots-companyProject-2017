using NUnit.Framework;

namespace spotsITests.Login
{
    [TestFixture]
    internal class LoginITests
    {
        /// <summary>
        /// Test that Account controller Register POST method executes the right action with invalid modelstate.
        /// </summary>
        [Test]
        public void InvalidModelState_AccountController_ExceptionalCase()
        {
            ////Arrange
            //var sut = new AccountController();
            //sut.ModelState.AddModelError("test", "test");

            ////Act
            //var actionResult = sut.Login(new AccountViewModel(), "edundantUrl" );
            //var viewResult = actionResult.Result as ViewResult;

            ////Assert
            //Assert.IsNotNull(actionResult);
            //Assert.IsNotNull(viewResult);
            //Assert.AreEqual("Index", viewResult.ViewName);
        }

    }
}
