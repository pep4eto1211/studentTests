using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.JsonModels
{
    public class QuestionEntry
    {
        public QuestionHeader Question
        {
            get; set;
        }

        public AnswerEntry[] Answers
        {
            get; set;
        }
    }
}
