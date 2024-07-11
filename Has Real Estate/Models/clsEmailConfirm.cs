using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Has_Real_Estate.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "yaraesmaiel123@outlook.com";
            var fPassword = "yara124578";

            var theMsg = new MailMessage();
            theMsg.From = new MailAddress(fMail);
            theMsg.Subject = subject;
            theMsg.To.Add(email);
            theMsg.Body = $"<html><body>{htmlMessage}</body></html>";
            theMsg.IsBodyHtml = true;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
            //                          | SecurityProtocolType.Tls11
            //                          | SecurityProtocolType.Tls12;
            var smtpClint = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 587,
                UseDefaultCredentials = false

            };

            smtpClint.Send(theMsg);
        }
    }
}
