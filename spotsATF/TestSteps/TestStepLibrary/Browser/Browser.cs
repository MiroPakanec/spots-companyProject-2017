using spotsATF.TestSteps.TestStepLibrary.Browser.GoToLocationTestStep;
using spotsATF.TestSteps.TestStepLibrary.Browser.HasLocationTestStep;

namespace spotsATF.TestSteps.TestStepLibrary.Browser
{
    public class Browser
    {
        public GoToLocation GoToLocation => new GoToLocation();
        public HasLocation HasLocation => new HasLocation();
        public HasTitle.HasTitle HasTitle => new HasTitle.HasTitle();
    }
}
