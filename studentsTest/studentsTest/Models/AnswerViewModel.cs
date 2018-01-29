using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.Models
{
    public class AnswerViewModel
    {
        public bool Answer
        {
            get; set;
        }

        public int QuestionCount
        {
            get; set;
        }

        public int CurrentQuestion
        {
            get; set;
        }

        public int Score
        {
            get; set;
        }

        public int TestId
        {
            get; set;
        }
    }
}
