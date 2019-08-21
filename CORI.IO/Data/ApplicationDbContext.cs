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
            //Database
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ContactMethod>().HasData(
                new ContactMethod { ContactMethodId = 1, Description = "30 Second Survey" },
                new ContactMethod { ContactMethodId = 2, Description = "Soul Winning" },
                new ContactMethod { ContactMethodId = 3, Description = "Event" },
                new ContactMethod { ContactMethodId = 4, Description = "Personal Invite" },
                new ContactMethod { ContactMethodId = 5, Description = "Website" },
                new ContactMethod { ContactMethodId = 6, Description = "Misc" }
            );

            builder.Entity<Question>().HasData(
                new Question { QuestionId = 1, Description = "Which of these is the most important for you to experience during college?" },
                new Question { QuestionId = 2, Description = "On a scale from 1-10 how important is the spiritual area of your life?" },
                new Question { QuestionId = 3, Description = "I am interested in hearing more about Driven Student Ministry" }
            );

        }

        public DbSet<ContactMethod> ContactMethods { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
    }
}
