namespace spots.Models.Account.Viewmodels.Extentions
{
    public static class AccountViewModelExtensions
    {
        public static AccountViewModel WithTypeLogin(this Models.Account.Viewmodels.AccountViewModel account)
        {
            account.Type = AccountTypes.Login;
            return account;
        }

        public static AccountViewModel WithTypeRegister(this Models.Account.Viewmodels.AccountViewModel account)
        {
            account.Type = AccountTypes.Register;
            return account;
        }
    }
}