using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace CORI.IO.Model
{
    public class CORIContext : DbContext
    {
        public CORIContext(DbContextOptions<CORIContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
    }

    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime ContactDate { get; set; }
        public bool IsSubscribed { get; set; }

        public ContactMethod ContactMethodId { get; set; }

    }

    public class ContactMethod
    {
        public int ContactMethodId { get; set; }
        public string Description { get; set; }

    }
}
