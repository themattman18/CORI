using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Models
{
    public class UserContact
    {
        public int UserContactId { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }
        
        public virtual Contact Contact { get; set; }
    }
}
