using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.JsonModels
{
    public class AnswerEntry
    {
        public object QuestionId
        {
            get; set;
        }

        public string Answer
        {
            get; set;
        }

        public bool IsCorrect
        {
            get; set;
        }

        public object Id
        {
            get; set;
        }
    }
}
