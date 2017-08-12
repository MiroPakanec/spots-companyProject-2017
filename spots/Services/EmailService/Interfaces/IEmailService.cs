using System.Net.Mail;

namespace spots.Services.EmailService.Interfaces
{
    public interface IEmailService
    {
        ITemplate Template { get; set; }
        void Send(MailMessage mailMessage);
    }
}
