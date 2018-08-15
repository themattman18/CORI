﻿using System;
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
        public string Phone { get; set; }

        [Required]
        public bool IsSubscribed { get; set; }

        [Required]
        public string MostImportantExperience { get; set; }

        [Required]
        public string SpiritualArea { get; set; }
    }
}
