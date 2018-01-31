using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentsTest.Models;

namespace studentsTest.Controllers
{
    public class ResultsController : Controller
    {
        private readonly StudentTestsContext _context;

        public ResultsController(StudentTestsContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var studentTestsContext = _context.Results.Where(e => e.UserId == 1).OrderByDescending(e => e.Id).Include(r => r.User);
            var user = await _context.Users.Where(e => e.Id == 1).SingleOrDefaultAsync();
            ViewBag.UserName = user.UserName;
            return View(await studentTestsContext.ToListAsync());
        }
        
        private bool ResultsExists(int id)
        {
            return _context.Results.Any(e => e.Id == id);
        }
    }
}
