using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using studentsTest.Models;
using studentsTest.Services;

namespace studentsTest.Controllers
{
    public class HomeController : Controller
    {
        private Lazy<TestsListService> _service = new Lazy<TestsListService>();
        private TestsListService _Service
        {
            get
            {
                return _service.Value;
            }
        }
        
        public IActionResult Index()
        {
            return View(_Service.GetTests());
        }

        public IActionResult Solve(int testId)
        {
            return RedirectToAction("Index", "Question", testId);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
