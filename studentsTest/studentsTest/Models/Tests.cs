using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class Tests
    {
        public Tests()
        {
            Questions = new HashSet<Questions>();
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }
        public string TestName { get; set; }

        public ICollection<Questions> Questions { get; set; }
        public ICollection<Results> Results { get; set; }
    }
}
