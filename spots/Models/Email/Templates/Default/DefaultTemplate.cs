using System.Net.Mail;
using spots.Services.EmailService.Extensions;

namespace spots.Models.Email.Templates.Default
{
    public class DefaultTemplate : IDefaultTemplate
    {
        public MailMessage ForgotPassword(string callbackUrl)
        {
            return new MailMessage()
                .WithSubject("Spots - Forgot password reset")
                .WithBody("Hello: " + callbackUrl)
                .WithHtmlBody();
        }

        public MailMessage ForgotPassword(string callbackUrl, string fname)
        {
            return new MailMessage()
                .WithSubject("Spots - Forgot password reset")
                .WithBody("Hello " + fname + ",<br /> To reset your password, please click on the following link:<br />" + callbackUrl)
                .WithHtmlBody();
        }

        public MailMessage Register(string callbackUrl, string fname)
        {
            return new MailMessage()
                .WithSubject("Spots - Thank you for your registration")
                .WithBody("Hello " + fname +
                          ",<br /> Thank you for registering on our website! Please click on the following ling and confirm your account:<br />" +
                          callbackUrl)
                .WithHtmlBody();
        }

        public MailMessage DeleteAccount(string code, string fname)
        {
            return new MailMessage()
                .WithSubject("Spots - Thank you for your registration")
                .WithBody("Hello " + fname +
                          ",<br /> We have recently recieved a request to delete your account - here is your verification code:<br />" + 
                          code + " <br /><br />We hope you have had a good time with us. See you around - the Spot team.<br />")
                .WithHtmlBody();
        }
    }
}