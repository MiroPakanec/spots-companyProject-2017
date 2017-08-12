using System.Net.Mail;
using spots.Services.EmailService.Interfaces;

namespace spots.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public ITemplate Template { get; set; }

        public void Send(MailMessage mailMessage)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Send(mailMessage);
            }
        }

        public EmailService(ITemplate template)
        {
            Template = template;
        }
    }
}