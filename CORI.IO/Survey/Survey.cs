using CORI.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
            
        }
    }
}
