using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORI.Models.SurveyViewModels
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
    }
}
