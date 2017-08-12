namespace spots.Models.Account.Interfaces
{
    public interface IRegister
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
    }
}
