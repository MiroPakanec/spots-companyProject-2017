using System;
using OpenQA.Selenium;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps
{
    public class ActionTestStep : IActionTestStep
    {
        private readonly Action<IWebDriver> _action;

        public ActionTestStep(Action<IWebDriver> action)
        {
            _action = action;
        }

        public void Execute(IWebDriver driver)
        {
            _action(driver);
        }
    }
}
