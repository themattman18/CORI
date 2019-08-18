using System;
using System.Collections;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace TwilioReceive.Controllers
{
    public class SmsController : TwilioController
    {
        private CORI.IO.Texting.ITexting TwilioTexting { get; set; }

        public SmsController(CORI.IO.Texting.ITexting textServiceLayer)
        {
            TwilioTexting = textServiceLayer ?? throw new ArgumentNullException();
        }

        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Thanks for contacting Driven!  A representative will get back to you as soon as possible.");

            TwilioTexting.RespondToText(incomingMessage.From, incomingMessage.Body);

            return TwiML(messagingResponse);
        }
    }
}