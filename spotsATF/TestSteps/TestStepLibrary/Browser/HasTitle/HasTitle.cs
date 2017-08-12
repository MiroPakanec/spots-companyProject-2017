using NUnit.Framework;
using spotsATF.TestSteps.Interfaces;

namespace spotsATF.TestSteps.TestStepLibrary.Browser.HasTitle
{
    public class HasTitle
    {
        public IVerificationTestStep EqualTo(string title)
        {
            return new VerificationTestStep(obj =>
            {
                Assert.IsNotNull(obj.Title);
                Assert.AreEqual(title, obj.Title);
            });
        }
    }
}
