using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class Results
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Result { get; set; }
        public string TestName { get; set; }

        public Users User { get; set; }
    }
}
