using System;
using System.Collections.Generic;

namespace studentsTest.Models
{
    public partial class Users
    {
        public Users()
        {
            Results = new HashSet<Results>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Results> Results { get; set; }
    }
}
