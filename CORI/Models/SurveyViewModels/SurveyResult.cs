using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORI.Models.SurveyViewModels
{
    public class SurveyResult
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MinLength(9, ErrorMessage = "Make sure you include the area code")]
        public string Phone { get; set; }

        [Required]
        public bool IsSubscribed { get; set; }

        [Required(ErrorMessage = "You must select the most import experience")]
        public string MostImportantExperience { get; set; }

        [Required(ErrorMessage = "You must select how important the spiritual area is")]
        public string SpiritualArea { get; set; }
    }
}
