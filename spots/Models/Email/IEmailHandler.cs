using System.Net.Mail;
using spots.Models.Email.Templates;

namespace spots.Models.Email
{
    public interface IEmailHandler
    {
        ITemplate Template { get; set; }
        void Send(MailMessage mailMessage);
    }
}
