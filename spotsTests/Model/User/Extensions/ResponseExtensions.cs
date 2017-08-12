using MongoDB.Driver;
using Moq;
using spots.Models.User.Interfaces;

namespace spotsTests.Model.User.Extensions
{
    public static class ResponseExtensions
    {
        public static Mock<IUserResponse> WithResponseText(this Mock<IUserResponse> mock, string responseText)
        {
            mock.SetupGet(m => m.ResponseText).Returns(responseText);
            return mock;
        }

        public static Mock<IUserResponse> WithSuccess(this Mock<IUserResponse> mock)
        {
            mock.SetupGet(m => m.Success).Returns(true);
            return mock;
        }

        public static Mock<IUserResponse> WithFailure(this Mock<IUserResponse> mock)
        {
            mock.SetupGet(m => m.Success).Returns(false);
            return mock;
        }

        public static Mock<IUserResponse> WithReplaceOneResult(this Mock<IUserResponse> mock, ReplaceOneResult result)
        {
            mock.SetupGet(m => m.Result).Returns(result);
            return mock;
        }
    }
}
