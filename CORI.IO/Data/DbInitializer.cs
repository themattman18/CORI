using CORI.Data;
using CORI.IO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORI.IO.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Add the contact methods
            if (!context.ContactMethods.Any())
            {
                var contactMethods = new ContactMethod[]
                {
                    new ContactMethod{ContactMethodId = 1, Description = "30 Second Survey"},
                    new ContactMethod{ContactMethodId = 2, Description = "Soul Winning"},
                    new ContactMethod{ContactMethodId = 3, Description = "Event"},
                    new ContactMethod{ContactMethodId = 4, Description = "Personal Invite"},
                    new ContactMethod{ContactMethodId = 5, Description = "Website"},
                    new ContactMethod{ContactMethodId = 6, Description = "Misc"},
                };

                foreach (var currentItem in contactMethods)
                {
                    context.ContactMethods.Add(currentItem);
                }
                context.SaveChanges();
            }

            // Add the questions
            if (!context.Questions.Any())
            {
                var questions = new Question[]
                {
                    new Question{QuestionId = 1, Description = "Which of these is the most important for you to experience during college?"},
                    new Question{QuestionId = 2, Description = "On a scale from 1-10 how important is the spiritual area of your life?"},
                    new Question{QuestionId = 3, Description = "I am interested in hearing more about Driven Student Ministry"},
                };

                foreach (var currentItem in questions)
                {
                    context.Questions.Add(currentItem);
                }
                context.SaveChanges();
            }

        }
    }
}
