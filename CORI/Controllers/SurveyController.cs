using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CORI.Data;
using CORI.IO.MailChimp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CORI.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        public IConfiguration Configuration { get; }
        private IHostingEnvironment _hostingEnvironment;
        private IEmailSync _mailChimpSync;


        public SurveyController(IConfiguration config, IHostingEnvironment environment, IEmailSync mainChimpSync)
        {
            Configuration = config;
            _hostingEnvironment = environment;
            _mailChimpSync = mainChimpSync ?? throw new ArgumentException();
        }

        public IActionResult Survey()
        {
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        /// <summary>
        /// Submit the survey the student filled out
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitSurvey(CORI.Models.SurveyViewModels.SurveyResult survey)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //var path = Path.Combine(_hostingEnvironment.WebRootPath, "emailTemplates\\basic.html");

                    string apiKey = Configuration["Authentication-Email-ApiKey"];
                    string fromEmail = Configuration["Settings-FromEmail"];
                    string fromName = Configuration["Settings-FromName"];
                    CORI.IO.Survey.Models.SurveyResult result = new IO.Survey.Models.SurveyResult()
                    {
                        ContactedBy = HttpContext.User.Identity.Name,
                        Email = survey.Email,
                        FirstName = survey.FirstName,
                        IsSubscribed = survey.IsSubscribed,
                        LastName = survey.LastName,
                        MostImportantExperience = survey.MostImportantExperience,
                        Phone = survey.Phone,
                        SpiritualArea = survey.SpiritualArea
                    };

                    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                    using (var context = new ApplicationDbContext(optionsBuilder.Options))
                    {
                        IO.Survey.Survey surveyIO = new IO.Survey.Survey(context);
                        IO.Email.Email emailIO = new IO.Email.Email(context, apiKey, fromEmail, fromName);
                        var newContact = surveyIO.SubmitSurvey(result);

                        var response = _mailChimpSync.SyncEmail(result);

                        //try
                        //{
                        //    var mailResult = emailIO.SendConfirmationEmail(newContact, path);
                        //}
                        //catch (Exception)
                        //{
                        //    // don't error out just because we couldn't send an email
                        //}
                    }

                    return View("~/Views/Survey/ThankYou.cshtml");
                }

                return View("~/Views/Survey/Survey.cshtml", survey);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Show a list of my contacts
        /// </summary>
        /// <returns></returns>
        public IActionResult MyContacts()
        {
            List<CORI.IO.Models.Contact> contacts;

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                IO.Survey.Survey surveyIO = new IO.Survey.Survey(context);
                contacts = surveyIO.GetMyContacts(HttpContext.User.Identity.Name);
            }

            return View(contacts);
        }

        /// <summary>
        /// Gets all the contacts
        /// </summary>
        /// <param name="contactData"></param>
        /// <returns></returns>
        public IActionResult GetContactDataView(int contactData)
        {
            List<CORI.IO.Models.Contact> contacts;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));


            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                IO.Survey.Survey surveyIO = new IO.Survey.Survey(context);

                if (contactData == 1)
                {
                    contacts = surveyIO.GetMyContacts(HttpContext.User.Identity.Name);
                }
                else
                {
                    contacts = surveyIO.GetAllContacts();
                }
            }

            return PartialView("ContactData", contacts);
        }
    }
}