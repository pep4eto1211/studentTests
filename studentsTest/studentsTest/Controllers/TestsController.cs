using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentsTest.Models;
using studentsTest.Services;

namespace studentsTest.Controllers
{
    public class TestsController : Controller
    {
        private readonly StudentTestsContext _context;
        private readonly ITeacherSystemService _teacherSystemService;

        public TestsController(StudentTestsContext context, ITeacherSystemService teacherSystemService)
        {
            _context = context;
            _teacherSystemService = teacherSystemService;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            PopulateTestsFromTeacherSystem();
            return View(await _context.Tests.ToListAsync());
        }
        
        // GET: Tests/Details/5
        public async Task<IActionResult> Solve(int? id)
        {
            var modelList = await _context.Questions.Where(e => e.TestId == id).Include(e => e.QuestionOptions).ToListAsync();
            if (modelList.Count != 0)
            {
                Questions model = modelList[0];
                
                ViewBag.QuestionCount = modelList.Count;
                ViewBag.CurrentQuestion = 1;
                ViewBag.Score = 0;
                ViewBag.TestId = id;
                return View(model); 
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> ReceiveAnswer(int score, int testId, bool answer, int currentQuestion, int questionCount)
        {
            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.Score = score;
            answerViewModel.Answer = answer;
            answerViewModel.CurrentQuestion = currentQuestion;
            answerViewModel.QuestionCount = questionCount;
            answerViewModel.TestId = testId;

            if (answerViewModel.Answer)
            {
                answerViewModel.Score++;
            }

            if (answerViewModel.CurrentQuestion < answerViewModel.QuestionCount)
            {
                var modelList = await _context.Questions.Where(e => e.TestId == testId).Include(e => e.QuestionOptions).ToListAsync();
                if (modelList.Count != 0)
                {
                    Questions model = modelList[answerViewModel.CurrentQuestion];

                    ViewBag.QuestionCount = modelList.Count;
                    ViewBag.CurrentQuestion = answerViewModel.CurrentQuestion + 1;
                    ViewBag.Score = answerViewModel.Score;
                    ViewBag.TestId = answerViewModel.TestId;
                    return View("Solve", model);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                await SaveScoreForUser(answerViewModel.TestId, answerViewModel.Score);
                return View("Score", answerViewModel.Score);
            }
        }

        private async Task SaveScoreForUser(int testId, int score)
        {
            var test = await  _context.Tests.Where(e => e.Id == testId).SingleOrDefaultAsync();
            string testName = test.TestName;
            _context.Results.Add(new Results()
            {
                Result = score,
                UserId = 1,
                TestName = testName
            });

            await _context.SaveChangesAsync();
        }

        public ActionResult Score()
        {
            return View();
        }

        private bool TestsExists(int id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }

        private void PopulateTestsFromTeacherSystem()
        {
            _teacherSystemService.LoadTests();
        }
    }
}
