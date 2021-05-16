using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Mailing
{
    public class SendGridEmailSender : IEmailSender
    {
        //private readonly SendGridClient client;
        //public SendGridEmailSender(string apiKey)
        //{
        //    this.client = new SendGridClient(apiKey);
        //}
        public Task SendEmailAsync(string from, string fromName, string to, string subject, string htmlContent, IEnumerable<EmailAttachment> attachments = null)
        {
            throw new NotImplementedException();
        }
    }
}
