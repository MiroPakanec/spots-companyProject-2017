using System.Net.Mail;
using spots.Models.Email.Templates;

namespace spots.Models.Email
{
    public class EmailHnadler : IEmailHandler
    {
        public EmailHnadler()
        {
            Template = new Template();
        }

        public ITemplate Template { get; set; }

        public void Send(MailMessage mailMemessage)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Send(mailMemessage);
            }
        }
    }
}