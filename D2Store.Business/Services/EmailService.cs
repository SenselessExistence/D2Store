using Castle.Core.Smtp;
using D2Store.Business.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace D2Store.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 465;
        private readonly string _smtpUsername = "knight.of.lotric@gmail.com";
        private readonly string _smtpPassword = "32184002Gb";

        public async Task SendEmailAsync(string email, string clientName)
        {
            string message = $"Dear {clientName}, you have successfully registered on the website D2Store.com.\nGood luck and may you have great winnings.";

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("D2Store", _smtpUsername));
            emailMessage.To.Add(new MailboxAddress(clientName, email));
            emailMessage.Subject = "Registration success";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, false);
                await client.AuthenticateAsync(_smtpUsername, _smtpPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
