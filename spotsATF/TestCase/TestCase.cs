using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestCase
{
    public class TestCase
    {
        private readonly List<ITestStep> _steps;
        private readonly IWebDriver _driver;

        private bool _wasExecuted;
        private bool _hasVerification;

        public TestCase()
        {
            _steps = new List<ITestStep>();
            _driver = new ChromeDriver();
        }

        public void AddAction(IActionTestStep step)
        {
            _steps.Add(step);
        }

        public void VerifyThat(IVerificationTestStep step)
        {
            _hasVerification = true;
            _steps.Add(step);
        }

        public void Execute()
        {
            _wasExecuted = true;
            foreach (var step in _steps)
            {
                step.Execute(_driver);
            }
        }

        public void IsValid()
        {
            Assert.That(_wasExecuted, "Execution method was never called.");
            Assert.IsNotEmpty(_steps, "At least one test step has to be supplied.");
            Assert.IsTrue(_hasVerification, "At least one verification test step has to be specified.");
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();

        }
    }
}
