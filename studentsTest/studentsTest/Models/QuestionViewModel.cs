using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.Models
{
    public class QuestionViewModel
    {
        public string Text
        {
            get; set;
        }

        public List<string> PossibleAnswers
        {
            get; set;
        }

        public int CorrectAnswerIndex
        {
            get; set;
        }

        public int QuestionId
        {
            get; set;
        }
    }
}
