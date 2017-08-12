using System.Net.Mail;

namespace spots.Services.EmailService.Extensions
{
    public static class MailMessageExtensions
    {
        public static MailMessage WithSubject(this MailMessage message, string subject)
        {
            message.Subject = subject;
            return message;
        }

        public static MailMessage WithReciever(this MailMessage message, string reciever)
        {
            message.To.Add(reciever);
            return message;
        }

        public static MailMessage WithBody(this MailMessage message, string body)
        {
            message.Body = body;
            return message;
        }

        public static MailMessage WithHtmlBody(this MailMessage message)
        {
            message.IsBodyHtml = true;
            return message;
        }

        public static MailMessage WithNonHtmlBody(this MailMessage message)
        {
            message.IsBodyHtml = false;
            return message;
        }
    }
}