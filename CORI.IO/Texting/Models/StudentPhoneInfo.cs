using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Texting.Models
{
    public class StudentPhoneInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName
        {
            get
            {
                return $"{FirstName} {LastName} - {Phone}";
            }
        }
        public string Phone { get; set; }
    }
}
