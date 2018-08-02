using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CORI.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MinLength(9, ErrorMessage = "You must enter your area code with your phone number")]
        public string Phone { get; set; }
    }
}
