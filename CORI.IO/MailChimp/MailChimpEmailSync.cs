using CORI.IO.Survey.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.MailChimp
{
    

    public class MailChimpEmailSync : IEmailSync
    {
        public string ApiKey { get; set; }
        public string ListId { get; set; }
        public string BaseUrl { get; set; }

        public MailChimpEmailSync(IOptionsMonitor<Models.EmailSyncSettings> optionsAccessor)
        {
            ApiKey = optionsAccessor.CurrentValue.ApiKey ?? throw new ArgumentNullException();
            ListId = optionsAccessor.CurrentValue.ListId ?? throw new ArgumentNullException();
            BaseUrl = optionsAccessor.CurrentValue.Url ?? throw new ArgumentNullException();
        }

        public RestResponse SyncEmail(SurveyResult newUser)
        {
            var subscribeRequest = new
            {
                email_address = newUser.Email,
	            email_type = "html",
	            status = "subscribed",
	            language= "en",
                merge_fields =
                new
                {
                    FNAME = newUser.FirstName,
                    LNAME = newUser.LastName,
                    PHONE = newUser.Phone
                },
                ip_opt = "true",
	            //tags = ""
            };

            RestClient client = new RestClient();
            client.BaseUrl = new Uri($"{BaseUrl}//lists//{ListId}//members");
            client.Authenticator =
                new HttpBasicAuthenticator("apikey", ApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter(@"application/json; charset=utf-8", JsonConvert.SerializeObject(subscribeRequest), ParameterType.RequestBody);
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        public void SyncEmail(List<string> emails)
        {
            throw new NotImplementedException();
        }

        public RestResponse GetAllUsers()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri($"{BaseUrl}//lists//{ListId}//members");
            client.Authenticator =
                new HttpBasicAuthenticator("apikey", ApiKey);
            RestRequest request = new RestRequest();
            //request.AddParameter("domain", "drivenstudents.org", ParameterType.UrlSegment);
            //request.Resource = "{domain}/messages";
            request.AddParameter("count", "500");
            //request.AddParameter("html", text);
            request.Method = Method.GET;
            return (RestResponse)client.Execute(request);
        }
    }
}
