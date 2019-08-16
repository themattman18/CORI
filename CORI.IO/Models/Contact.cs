using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        //public int ContactMethodId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ContactDate { get; set; }
        public bool IsSubscribed { get; set; }

        public virtual ContactMethod ContactMethod { get; set; }
    }
}
