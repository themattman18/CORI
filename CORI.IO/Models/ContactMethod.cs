using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CORI.IO.Models
{
    public class ContactMethod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContactMethodId { get; set; }
        public string Description { get; set; }

    }
}
