using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Browser.GoToLocationTestStep
{
    public class GoToLocation
    {
        public IActionTestStep Login
        {
            get
            {
                return new ActionTestStep(driver =>
                {
                    const string url = "https://localhost:44371/Account/Login";
                    driver.Navigate().GoToUrl(url);
                });
            }

        }

        public IActionTestStep Register
        {
            get
            {
                return new ActionTestStep(driver =>
                {
                    const string url = "https://localhost:44371/Account/Register";
                    driver.Navigate().GoToUrl(url);
                });
            }
        }
    }
}
