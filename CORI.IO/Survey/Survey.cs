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
        public void SubmitSurvey(Models.SurveyResult survey)
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
                    ContactMethodId = surveyMethod
                });

                appCxt.SaveChanges();

                contact = (from x in appCxt.Contacts
                           where x.Email == survey.Email
                           select x).First();
            }


            var questions = (from x in appCxt.Questions
                             select x).ToList();

            // Save the answers
            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                ContactId = contact,
                Answer = survey.MostImportantExperience,
                QuestionId = questions.Where(x => x.QuestionId == 1).First()
            });

            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                ContactId = contact,
                Answer = survey.SpiritualArea,
                QuestionId = questions.Where(x => x.QuestionId == 2).First()
            });

            appCxt.SurveyResults.Add(new IO.Models.SurveyResult()
            {
                ContactId = contact,
                Answer = survey.IsSubscribed.ToString(),
                QuestionId = questions.Where(x => x.QuestionId == 3).First()
            });


            // Insert the survey
            appCxt.SaveChanges();
        }
    }
}
