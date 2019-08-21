using CORI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CORI.IO.Survey
{
    public class Survey
    {
        /// <summary>
        /// This needs to be interfaced out
        /// </summary>
        ApplicationDbContext appCxt;

        public Survey(ApplicationDbContext myContext)
        {
            appCxt = myContext;
        }

        /// <summary>
        /// Saves a survey
        /// </summary>
        /// <param name="survey"></param>
        public IO.Models.Contact SubmitSurvey(Models.SurveyResult survey)
        {

            // Create the contact if it doesn't exist
            var contact = (from x in appCxt.Contacts
                           where x.Email == survey.Email
                           select x).FirstOrDefault();


            if (contact == null)
            {
                var surveyMethod = (from x in appCxt.ContactMethods
                                    where x.Description == "30 Second Survey"
                                    select x).First();

                appCxt.Contacts.Add(new IO.Models.Contact()
                {
                    ContactDate = DateTime.Now,
                    Email = survey.Email,
                    FirstName = survey.FirstName,
                    LastName = survey.LastName,
                    IsSubscribed = survey.IsSubscribed,
                    Phone = survey.Phone,
                    //ContactMethod = surveyMethod
                });

                appCxt.SaveChanges();

                contact = (from x in appCxt.Contacts
                           where x.Email == survey.Email
                           select x).First();
                var appUser = (from x in appCxt.Users
                               where x.Email == survey.ContactedBy
                               select x).FirstOrDefault();

                // Tie this contact to the person who contacted them
                appCxt.UserContacts.Add(new IO.Models.UserContact()
                {
                    ApplicationUser = appUser,
                    Contact = contact
                });
            }

            var questions = (from x in appCxt.Questions
                             select x).ToList();

            // Save the answers
            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                Contact = contact,
                Answer = survey.MostImportantExperience,
                Question = questions.Where(x => x.QuestionId == 1).First()
            });

            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                Contact = contact,
                Answer = survey.SpiritualArea,
                Question = questions.Where(x => x.QuestionId == 2).First()
            });

            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                Contact = contact,
                Answer = survey.IsSubscribed.ToString(),
                Question = questions.Where(x => x.QuestionId == 3).First()
            });


            // Insert the survey
            appCxt.SaveChanges();

            return contact;
        }

        /// <summary>
        /// Get a list of people the user has contacted
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<IO.Models.Contact> GetMyContacts(string userName)
        {
            List<IO.Models.Contact> myContacts = null;

            if (!string.IsNullOrEmpty(userName))
            {
                myContacts = (from x in appCxt.Contacts
                              join y in appCxt.UserContacts on x equals y.Contact
                              join z in appCxt.Users on y.ApplicationUser equals z
                              where z.Email == userName
                              select x).ToList();
            }

            return myContacts;
        }

        /// <summary>
        /// Gets a list of all the contacts
        /// </summary>
        /// <returns></returns>
        public List<IO.Models.Contact> GetAllContacts()
        {
            List<IO.Models.Contact> myContacts = (from x in appCxt.Contacts
                                                  select x).ToList();

            return myContacts;
        }

    }
}
