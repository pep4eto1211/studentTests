using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class QuestionOptions
    {
        public int Id { get; set; }
        public string OptionText { get; set; }
        public int QuestionId { get; set; }

        public Questions Question { get; set; }
    }
}
