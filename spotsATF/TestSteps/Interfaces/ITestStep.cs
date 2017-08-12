using OpenQA.Selenium;

namespace spotsATF.TestSteps.Interfaces
{
    public interface ITestStep
    {
        void Execute(IWebDriver driver);
    }
}
