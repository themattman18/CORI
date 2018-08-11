using System;
using System.Collections.Generic;
using System.Text;
using CORI.IO.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CORI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
    }
}
