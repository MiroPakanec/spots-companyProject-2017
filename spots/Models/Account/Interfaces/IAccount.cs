namespace spots.Models.Account.Interfaces
{
    public interface IAccount
    {
        string Type { get; }
        string ReturnUrl { get; set; }

        bool IsLogin { get; }
        bool IsRegister { get; }

        void SetLogin();
        void SetRegister();
    }
}
