using System.Web;
using System.Web.Mvc;
using Moq;

namespace spotsTests.Controller.Extensions
{
    public static class ControllerContextExtensions
    {
        public static Mock<ControllerContext> WithHttpContextBase(this Mock<ControllerContext> mock, HttpContextBase context)
        {
            mock.SetupGet(m => m.HttpContext).Returns(context);
            return mock;
        }
    }
}
