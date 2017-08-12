using System.Net.Mail;

namespace spots.Models.Email.Templates.Default
{
    public interface IDefaultTemplate
    {
        MailMessage ForgotPassword(string callbackUrl);
        MailMessage ForgotPassword(string callbackUrl, string fname);
        MailMessage Register(string callbackUrl, string fname);
        MailMessage DeleteAccount(string code, string fname);
    }
}
