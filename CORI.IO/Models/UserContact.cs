using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Models
{
    public class UserContact
    {
        public int UserContactId { get; set; }
        public ApplicationUser ApplicationUserId { get; set; }
        public Contact ContactId { get; set; }
    }
}
