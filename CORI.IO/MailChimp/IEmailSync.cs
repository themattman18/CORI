using CORI.IO.Survey.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.MailChimp
{
    public interface IEmailSync
    {
        RestResponse SyncEmail(SurveyResult newUser);

    }
}
