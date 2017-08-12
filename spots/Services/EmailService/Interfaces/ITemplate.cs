using System.Net.Mail;

namespace spots.Services.EmailService.Interfaces
{
    public interface ITemplate
    {
        MailMessage ForgotPassword(string callbackUrl, string fname, string recieverEmail);
        MailMessage Register(string callbackUrl, string fname, string recieverEmail);
        MailMessage DeleteAccount(string code, string fname, string recieverEmail);
    }
}
