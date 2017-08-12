using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using spots.Models.Account.Interfaces;

namespace spotsTests.Model.Account.Extensions
{
    public static class AccountExtensions
    {
        public static Mock<IAccount> WithReturnUrl(this Mock<IAccount> mock, string returnUrl)
        {
            mock.Setup(m => m.ReturnUrl).Returns(returnUrl);
            return mock;
        }
    }
}
