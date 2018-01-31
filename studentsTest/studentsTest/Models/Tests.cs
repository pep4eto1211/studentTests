using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class Tests
    {
        public Tests()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public string TestName { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
