using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
//using MimeKit;
using System.Net.Mail;

namespace TestIT.Data.Managers
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("LambdaTeam@TestIT.com", "LambdaTeam"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }


        public void Mail(string subject, string messageToSend, string email)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress("TestIT-mailService", "bogosavljevic.1911@gmail.com"));
            //message.To.Add(new MailboxAddress("Deer User", email));
            //message.Subject = subject;

            //message.Body = new TextPart("plain")
            //{
            //    Text = "Hello,\n" + messageToSend + " \n have a nice day"
            //};
            //using (var client = new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587, false);
            //    client.Authenticate("vamosalaplayaagencija", sifraa);
            //    client.Send(message);
            //    client.Disconnect(true);
            //}
        }
    }

    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
