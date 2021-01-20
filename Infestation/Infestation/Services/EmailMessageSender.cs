using Infestation.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infestation.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly InfestationConfiguration _configuration;

        public EmailMessageSender(IOptions<InfestationConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage()
        {
            //Add header 
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Infestation", _configuration.EmailAddress));
            message.To.Add(new MailboxAddress("Ruslan", "ra.antoshkin@gmail.com"));
            message.Subject = "Infestation notification";

            //Add body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello world!<h1>";
            bodyBuilder.TextBody = "Hello world!";
            message.Body = bodyBuilder.ToMessageBody();

            //Send
            using (SmtpClient client  = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(_configuration.EmailAddress, _configuration.EmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}