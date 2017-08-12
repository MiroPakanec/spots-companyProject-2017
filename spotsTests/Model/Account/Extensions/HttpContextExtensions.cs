using System.Security.Principal;
using System.Web;
using Moq;

namespace spotsTests.Model.Account.Extensions
{
    public static class HttpContextExtensions
    {
        public static Mock<HttpContextBase> WithUserIdentity(this Mock<HttpContextBase> mock, IPrincipal identity)
        {
            mock.Setup(m => m.User).Returns(identity);
            return mock;
        }
    }
}
