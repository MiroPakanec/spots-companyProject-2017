using System;
using OpenQA.Selenium;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps
{
    public class VerificationTestStep : IVerificationTestStep
    {
        private readonly Action<IWebDriver> _action;

        public VerificationTestStep(Action<IWebDriver> action)
        {
            _action = action;
        }

        public void Execute(IWebDriver driver)
        {
            _action(driver);
        }
    }
}
