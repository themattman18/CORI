using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CORI.IO.Texting
{
    public class Texting : ITexting
    {
        private Models.TextingSettings settings { get; set; }

        public Texting(IOptionsMonitor<Models.TextingSettings> optionsAccessor)
        {
            settings = optionsAccessor.CurrentValue ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Sends a text to the specified number
        /// </summary>
        /// <param name="textingMessage"></param>
        public void SendText(Models.TextingViewModel textingMessage)
        {
            TwilioClient.Init(settings.AccountSid, settings.AuthToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(textingMessage.PhoneNumber));
            messageOptions.From = new PhoneNumber(settings.FromPhoneNumber);
            messageOptions.Body = textingMessage.Message;

            var messageResource = MessageResource.Create(messageOptions);
        }

    }
}
