using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CORI.Controllers
{
    [Authorize]
    public class SurveyController : Controller
    {
        public IActionResult Survey()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSurvey(CORI.Models.SurveyViewModels.SurveyResult survey)
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

                //IO.Survey.Survey surveyIO = new IO.Survey.Survey(new Data.ApplicationDbContext());
                //surveyIO.SubmitSurvey(result);
            }
                        

            return View("~/Views/Survey/ThankYou.cshtml");
        }
    }
}