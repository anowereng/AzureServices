using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailSender
{
    public class SendGridMailService: IMailSenderService
    {
        public async Task<bool> SendAsync(string to , string subject, string content)
        {
            try
            {
                var apiKey = MailSettings.SendGridAPIKey;
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(MailSettings.FromEmailAddress, MailSettings.FromName),
                    Subject = subject,
                    PlainTextContent = content,
                    HtmlContent = $"<strong>{content}</strong>"
                };
                msg.AddTo(new EmailAddress(to));
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
