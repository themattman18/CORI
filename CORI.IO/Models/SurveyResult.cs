using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Models
{
    public class SurveyResult
    {
        public int SurveyResultId { get; set; }
        public Contact ContactId { get; set; }
        public Question QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
