using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Texting
{
    public interface ITexting
    {
        void SendText(List<IO.Texting.Models.StudentPhoneInfo> studentsToText, string message);
        List<Models.StudentPhoneInfo> GetPhoneNumbers();
        void RespondToText(string from, string message);
    }
}
