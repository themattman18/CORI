using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Texting.Models
{
    public class TextingSettings
    {
        public string AccountSid { get; set; }
        public string FromPhoneNumber { get; set; }
        public string AuthToken { get; set; }
    }
}
