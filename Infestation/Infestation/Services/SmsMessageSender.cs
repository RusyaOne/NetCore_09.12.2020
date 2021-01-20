using System;
using Infestation.Configurations;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace Infestation.Services
{
    public class SmsMessageSender : IMessageSender
    {
        private readonly InfestationConfiguration _configuration;

        public SmsMessageSender(IOptions<InfestationConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage()
        {
            TwilioClient.Init(_configuration.TwilioAccountId, _configuration.TwilioAuthToken);

            var message = MessageResource.Create(
                from: new PhoneNumber(_configuration.TwilioNumber), 
                to: new PhoneNumber(_configuration.MyNumber),
                body: "Infestation notification!");

            Console.WriteLine(message.Status);
        }
    }
}
