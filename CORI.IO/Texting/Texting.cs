using CORI.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Linq;

namespace CORI.IO.Texting
{
    public class Texting : ITexting
    {
        private Models.TextingSettings settings { get; set; }

        /// <summary>
        /// This needs to be interfaced out
        /// </summary>
        ApplicationDbContext appCxt;

        public Texting(IOptionsMonitor<Models.TextingSettings> optionsAccessor, ApplicationDbContext context)
        {
            settings = optionsAccessor.CurrentValue ?? throw new ArgumentNullException();
            appCxt = context ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Sends a text to the specified number
        /// </summary>
        /// <param name="textingMessage"></param>
        public void SendText(List<IO.Texting.Models.StudentPhoneInfo> studentsToText, string message)
        {
            TwilioClient.Init(settings.AccountSid, settings.AuthToken);

            foreach (var item in studentsToText)
            {
                var messageOptions = new CreateMessageOptions(
                new PhoneNumber(item.Phone));
                messageOptions.From = new PhoneNumber(settings.FromPhoneNumber);
                messageOptions.Body = message.Replace("[Name]", item.FirstName);

                var messageResource = MessageResource.Create(messageOptions);
            }
        }

        public List<Models.StudentPhoneInfo> GetPhoneNumbers()
        {
            List<Models.StudentPhoneInfo> allStudents = new List<Models.StudentPhoneInfo>();

            allStudents = (from x in appCxt.Contacts
                           select new Models.StudentPhoneInfo()
                           {
                               Id = x.ContactId,
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               Phone = x.Phone
                           }).ToList();

            return allStudents;

        }

    }
}
