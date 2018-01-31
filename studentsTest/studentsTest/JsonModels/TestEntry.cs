using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.JsonModels
{
    public class TestEntry
    {
        public Test Test
        {
            get; set;
        }

        public QuestionEntry[] Questions
        {
            get; set;
        }
    }
}
