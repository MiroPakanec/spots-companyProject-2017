using NUnit.Framework;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Browser.HasLocationTestStep
{
    public class HasLocation
    {
        public IVerificationTestStep Login
        {
            get
            {
                return new VerificationTestStep(driver =>
                {
                    const string url = "https://localhost:44371/Account/Login";

                    Assert.IsNotNull(driver.Url);
                    Assert.AreEqual(url, driver.Url);
                });
            }
        }

        public IVerificationTestStep Register
        {
            get
            {
                return new VerificationTestStep(driver =>
                {
                    const string url = "https://localhost:44371/Account/Register";

                    Assert.IsNotNull(driver.Url);
                    Assert.AreEqual(url, driver.Url);
                });
            }
        }
    }
}
