using spots.Models.Account.Interfaces;

namespace spots.Models.Account.Viewmodels
{
    public class AccountViewModel : IAccount
    {
        public AccountViewModel(ILogin login, IRegister register)
        {
            Login = login;
            Register = register;

            SetLogin();
        }

        public ILogin Login { get; }
        public IRegister Register { get; }

        public string Type { get; set; }
        public string ReturnUrl { get; set; }

        public bool IsLogin => Type == AccountTypes.Login;
        public bool IsRegister => Type == AccountTypes.Register;

        public void SetLogin()
        {
            Type = AccountTypes.Login;
        }

        public void SetRegister()
        {
            Type = AccountTypes.Register;
        }
    }
}