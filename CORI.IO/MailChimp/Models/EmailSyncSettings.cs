using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.MailChimp.Models
{
    public class EmailSyncSettings
    {
        public string ApiKey { get; set; }
        public string ListId { get; set; }
        public string Url { get; set; }
    }
}
