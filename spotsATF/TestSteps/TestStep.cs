using spotsATF.TestSteps.TestStepLibrary.Browser;
using spotsATF.TestSteps.TestStepLibrary.Database;

namespace spotsATF.TestSteps
{
    public class TestStep
    {
        public static Browser Browser => new Browser();
        public static Page.Page Page => new Page.Page();
        public static Database Database => new Database();
    }
}
