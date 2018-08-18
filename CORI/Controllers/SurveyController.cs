using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CORI.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        public IConfiguration Configuration { get; }

        public SurveyController(IConfiguration config)
        {
            Configuration = config;
        }

        public IActionResult Survey()
        {
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSurvey(CORI.Models.SurveyViewModels.SurveyResult survey)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
                        surveyIO.SubmitSurvey(result);
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
    }
}