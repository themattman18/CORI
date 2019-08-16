using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Models
{
    public class SurveyResult
    {
        public int SurveyResultId { get; set; }
        //public int ContactId { get; set; }
        //public int QuestionId { get; set; }
        public string Answer { get; set; }

        public virtual Question Question { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
