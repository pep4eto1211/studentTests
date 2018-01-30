using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class Questions
    {
        public Questions()
        {
            QuestionOptions = new HashSet<QuestionOptions>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int TestId { get; set; }

        public Tests Test { get; set; }
        public ICollection<QuestionOptions> QuestionOptions { get; set; }
    }
}
