using studentsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.Services
{
    public class TestsListService
    {
        public List<TestListVeiwModel> GetTests()
        {
            List<TestListVeiwModel> tests = new List<TestListVeiwModel>();
            for (int i = 0; i < 10; i++)
            {
                tests.Add(new TestListVeiwModel()
                {
                    TestName = $"Test {i.ToString()}",
                    TestId = i
                });
            }

            return tests;
        }
    }
}
