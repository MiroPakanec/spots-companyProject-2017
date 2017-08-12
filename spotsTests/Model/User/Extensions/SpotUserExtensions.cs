using MongoDB.Bson;
using Moq;
using spots.Models.User.Interfaces;

namespace spotsTests.Model.User.Extensions
{
    public static class SpotUserExtensions
    {
        public static Mock<ISpotUser> WithId(this Mock<ISpotUser> mock, ObjectId id)
        {
            mock.SetupGet(m => m.Id).Returns(id);
            return mock;
        }

        public static Mock<ISpotUser> WithId(this Mock<ISpotUser> mock, string id)
        {
            mock.SetupGet(m => m.Id).Returns(ObjectId.Parse(id));
            return mock;
        }

        public static Mock<ISpotUser> WithEmail(this Mock<ISpotUser> mock, string email)
        {
            mock.Setup(m => m.Email).Returns(email);
            return mock;
        }

        public static Mock<ISpotUser> WithFirstName(this Mock<ISpotUser> mock, string fname)
        {
            mock.Setup(m => m.FirstName).Returns(fname);
            return mock;
        }

        public static Mock<ISpotUser> WithRepositoryUser(this Mock<ISpotUser> mock, ISpotUser user)
        {
            mock.Setup(m => m.Repository.GetWithEmail(user.Email)).Returns(user);
            mock.Setup(m => m.Repository.GetWithId(user.Id)).Returns(user);
            return mock;
        }
    }
}
