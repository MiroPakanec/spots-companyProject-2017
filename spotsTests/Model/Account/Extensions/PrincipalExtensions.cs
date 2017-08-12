using System.Security.Principal;
using Moq;

namespace spotsTests.Model.Account.Extensions
{
    public static class PrincipalExtensions
    {
        public static Mock<IPrincipal> IsInRole(this Mock<IPrincipal> mock, string role)
        {
            mock.Setup(m => m.IsInRole(role)).Returns(true);
            return mock;
        }

        public static Mock<IPrincipal> IsAuthenticated(this Mock<IPrincipal> mock)
        {
            mock.SetupGet(m => m.Identity.IsAuthenticated).Returns(true);
            return mock;
        }

        public static Mock<IPrincipal> IsNotAuthenticated(this Mock<IPrincipal> mock)
        {
            mock.SetupGet(m => m.Identity.IsAuthenticated).Returns(false);
            return mock;
        }

        public static Mock<IPrincipal> WithIdentityName(this Mock<IPrincipal> mock, string identityName)
        {
            mock.SetupGet(m => m.Identity.Name).Returns(identityName);
            return mock;
        }
    }
}
