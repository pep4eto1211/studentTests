using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentsTest.Models;

namespace studentsTest.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Results")]
    public class ResultsController : Controller
    {
        private readonly StudentTestsContext _context;

        public ResultsController(StudentTestsContext context)
        {
            _context = context;
        }

        // GET: api/Results
        [HttpGet]
        public IEnumerable<Results> GetResults()
        {
            return _context.Results;
        }

        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResults([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var results = await _context.Results.SingleOrDefaultAsync(m => m.Id == id);

            if (results == null)
            {
                return NotFound();
            }

            return Ok(results);
        }
        
        private bool ResultsExists(int id)
        {
            return _context.Results.Any(e => e.Id == id);
        }
    }
}