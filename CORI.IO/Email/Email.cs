using CORI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace CORI.IO.Email
{
    public class Email
    {
        /// <summary>
        /// This needs to be interfaced out
        /// </summary>
        ApplicationDbContext appCxt;

        string apiKey;

        string _fromEmail;

        string _fromName;


        public Email(ApplicationDbContext myContext, string incomingApiKey, string fromEmail, string fromName)
        {
            appCxt = myContext;
            apiKey = incomingApiKey;
            _fromEmail = fromEmail;
            _fromName = fromName;
        }

        /// <summary>
        /// Unsubscribe a user from communications
        /// </summary>
        /// <param name="survey"></param>
        //public void Unsubscribe(string email)
        //{
        //    // Create the contact if it doesn't exist
        //    var contact = (from x in appCxt.Contacts
        //                   where x.Email == email
        //                   select x).FirstOrDefault();

        //    if (contact != null)
        //    {
        //        contact.IsSubscribed = false;
        //        appCxt.Contacts.Update(contact);
        //        appCxt.SaveChanges();
        //    }
        //    else
        //    {
        //        throw new ArgumentException($"Unable to find user {email}");
        //    }
        //}


        public RestResponse SendConfirmationEmail(IO.Models.Contact newContact, string emailTemplatePath)
        {

            string text;
            using (var reader = new System.IO.StreamReader(emailTemplatePath, System.Text.Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }

            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/");
            client.Authenticator =
                new HttpBasicAuthenticator("api", apiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "drivenstudents.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", FormatEmail(_fromName, _fromEmail));
            request.AddParameter("to", FormatEmail(newContact));
            request.AddParameter("subject", "Thanks for taking our survey");
            request.AddParameter("html", text);
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        /// <summary>
        /// Format the email in a way that mail gun can use
        /// </summary>
        /// <param name="newContact"></param>
        /// <returns></returns>
        private string FormatEmail(IO.Models.Contact newContact)
        {
            return FormatEmail(newContact.FirstName + " " + newContact.LastName, newContact.Email);
        }

        /// <summary>
        /// Format the email in a way that mail gun can use
        /// </summary>
        /// <param name="newContact"></param>
        /// <returns></returns>
        private string FormatEmail(string name, string email)
        {
            return $"{name} <{email}>";
        }
    }
}
