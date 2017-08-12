namespace spots.Models.Account.Interfaces
{
    public interface ILogin
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
        string ReturnUrl { get; set; }
    }
}
