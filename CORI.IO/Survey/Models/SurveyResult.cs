using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Survey.Models
{
    public class SurveyResult
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsSubscribed { get; set; }

        public string MostImportantExperience { get; set; }

        public string SpiritualArea { get; set; }

        public string ContactedBy { get; set; }
    }
}
