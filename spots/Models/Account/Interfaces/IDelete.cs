namespace spots.Models.Account.Interfaces
{
    public interface IDelete
    {
        string Email { get; set; }
        string Code { get; set; }
        string GeneratedCode { get; set; }
        string Password { get; set; }

        void GenerateCode(int length);
    }
}
