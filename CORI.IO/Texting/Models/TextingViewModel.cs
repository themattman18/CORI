using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CORI.IO.Texting.Models
{
    public class TextingViewModel
    {
        [Required]
        [Phone]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
