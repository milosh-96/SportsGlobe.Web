using Microsoft.AspNetCore.Identity.UI.Services;
using SportsGlobe.Web.Domain.Settings;
using System.Net.Mail;
using System.Net;

namespace SportsGlobe.Web.Infrastructure
{
    public class MailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        private readonly MailSettings mailSettings;
        public MailSender(IConfiguration configuration)
        {
            _configuration = configuration;

            mailSettings = new MailSettings();
            try
            {
                mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Couldn't parse values!");
            }

        }
        
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(mailSettings.Host, mailSettings.Port);
            NetworkCredential credentials = new NetworkCredential(mailSettings.UserName, mailSettings.Password);

            client.Credentials = credentials;

            // construct mailmessage object //
            MailMessage message = new MailMessage("noreply-sports@dbmilos.com", email, subject, htmlMessage);
            // force html formatting
            message.IsBodyHtml = true;

            // send
            client.SendAsync(message, credentials.UserName);
            client.SendCompleted += (sender, e) =>
            {
                Console.WriteLine("Done!");
            };

        }
    }
}
