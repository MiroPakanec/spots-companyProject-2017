using System;
using NUnit.Framework;
using spotsATF.TestSteps;

namespace spotsATF.spots_aTests.pages.authentication
{
    [TestFixture]
    public class RegisterUser
    {
        private TestCase.TestCase _testCase;

        [SetUp]
        public void SetUp()
        {
            _testCase = new TestCase.TestCase();
        }

        [TearDown]
        public void TearDown()
        {       
            _testCase.IsValid();
            _testCase.Dispose();
        }

        /// <summary>
        /// User registration test. Unauthorized user can be registered.
        /// </summary>
        [Test]
        public void Register_SubmitButton_HappyPath()
        {
            const string email = "miropakanec@gmail.test";
            const string fname = "testfname";
            const string lname = "testlname";
            const string password = "Testpassword1.";
            const string passwordConfirm = "Testpassword1.";

            //------------------------------------------------------------------------------------------------
            // Action:
            // Go to registration page.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Browser.GoToLocation.Register);
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // User is on the registration page.
            //------------------------------------------------------------------------------------------------            
            _testCase.VerifyThat(TestStep.Browser.HasLocation.Register);
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter email the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_Email").EnterValue(email));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Email input field has a value of email.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Email").HasValueEqualTo(email));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter first name into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_FirstName").EnterValue(fname));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // First name input field has a value of first name.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_FirstName").HasValueEqualTo(fname));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter last name into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_LastName").EnterValue(lname));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Last name input field has a value of last name.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_LastName").HasValueEqualTo(lname));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter password into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_Password").EnterValue(password));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Password input field has a value of password.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Password").HasValueEqualTo(password));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter confirm password into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_ConfirmPassword").EnterValue(passwordConfirm));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Confirm password input field has a value of confirm password.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_ConfirmPassword").HasValueEqualTo(passwordConfirm));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Click on the clear button.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("register-button").ClickAndWait(TimeSpan.FromSeconds(5)));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Page content has changed.
            // Registered user exists in the MognoDatabase.
            // Registered user exists in the SQL database.
            //------------------------------------------------------------------------------------------------
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("confirm-email-message").IsVisible);  
            _testCase.VerifyThat(TestStep.Database.Sql.User.WithEmail(email).Exists);
            _testCase.VerifyThat(TestStep.Database.Mongo.User.WithEmail(email).Exists);
            //------------------------------------------------------------------------------------------------
            // Action:
            // Delete User from SQL database.
            // Delete User from Mongo Database.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Database.Sql.User.WithEmail(email).Delete);
            _testCase.AddAction(TestStep.Database.Mongo.User.WithEmail(email).Delete);
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // User was deleted from SQL database.
            // User was deleted from Mongo database.
            //------------------------------------------------------------------------------------------------
            _testCase.VerifyThat(TestStep.Database.Sql.User.WithEmail(email).WasDeleted);
            _testCase.VerifyThat(TestStep.Database.Mongo.User.WithEmail(email).WasDeleted);

            _testCase.Execute();
        }

        /// <summary>
        /// User registration test. Unauthorized user can be registered.
        /// </summary>
        [Test]
        public void Register_ClearButton_HappyPath()
        {
            const string email = "testmail@gmail.com";
            const string fname = "testfname";
            const string lname = "testlname";
            const string password = "Testpassword1.";
            const string passwordConfirm = "Testpassword1.";

            //------------------------------------------------------------------------------------------------
            // Action:
            // Go to registration page.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Browser.GoToLocation.Register);
            //------------------------------------------------------------------------------------------------
            // Verification: 
            // User is on the registration page.
            // Page title is equal to 'Welcome - Spots'
            // Page header element has a value of 'Register'
            // Page sub-header element has a value of 'Create new account'
            //------------------------------------------------------------------------------------------------            
            _testCase.VerifyThat(TestStep.Browser.HasLocation.Register);
            _testCase.VerifyThat(TestStep.Browser.HasTitle.EqualTo("Welcome - Spots"));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithTag("h2").HasValueEqualTo("Register"));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithTag("h4").HasValueEqualTo("Create a new account"));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter email the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_Email").EnterValue(email));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Email input field has a value of email.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Email").HasValueEqualTo(email));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter first name into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_FirstName").EnterValue(fname));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // First name input field has a value of first name.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_FirstName").HasValueEqualTo(fname));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter last name into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_LastName").EnterValue(lname));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Last name input field has a value of last name.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_LastName").HasValueEqualTo(lname));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter password into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_Password").EnterValue(password));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Password input field has a value of password.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Password").HasValueEqualTo(password));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Enter confirm password into the registration form.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("RegisterViewModel_ConfirmPassword").EnterValue(passwordConfirm));
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Confirm password input field has a value of confirm password.
            //------------------------------------------------------------------------------------------------  
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_ConfirmPassword").HasValueEqualTo(passwordConfirm));
            //------------------------------------------------------------------------------------------------
            // Action:
            // Click on the clear button.
            //------------------------------------------------------------------------------------------------
            _testCase.AddAction(TestStep.Page.Register.Element.WithId("reset-button").Click);
            //------------------------------------------------------------------------------------------------
            // Verification : 
            // Every field of the registration form has empty value.
            //------------------------------------------------------------------------------------------------ 
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Email").HasValueEqualTo(string.Empty));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_FirstName").HasValueEqualTo(string.Empty));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_LastName").HasValueEqualTo(string.Empty));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_Password").HasValueEqualTo(string.Empty));
            _testCase.VerifyThat(TestStep.Page.Register.Element.WithId("RegisterViewModel_ConfirmPassword").HasValueEqualTo(string.Empty));

            _testCase.Execute();
        }
    }
}
