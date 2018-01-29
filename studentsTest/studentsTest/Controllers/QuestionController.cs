using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentsTest.Models;
using studentsTest.Services;

namespace studentsTest.Controllers
{
    public class QuestionController : Controller
    {
        private Lazy<QuestionsService> _service = new Lazy<QuestionsService>();
        private QuestionsService _Service
        {
            get
            {
                return _service.Value;
            }
        }

        // GET: Question
        public ActionResult Index(int testId)
        {
            QuestionViewModel model = _Service.GetQuestion(testId, 0, out int allQuestionsCount);
            ViewBag.QuestionCount = allQuestionsCount;
            ViewBag.CurrentQuestion = 1;
            ViewBag.Score = 0;
            ViewBag.TestId = 0;
            return View(model);
        }
        
        public IActionResult ReceiveAnswer(int score, int testId, bool answer, int currentQuestion, int questionCount)
        {
            /*
             * answer = i == Model.CorrectAnswerIndex,
            questionCount = ViewBag.QuestionCount,
            currentQuestion = ViewBag.CurrentQuestion,
            score = ViewBag.Score,
            testId = ViewBag.TestId
             */

            AnswerViewModel answerViewModel = new AnswerViewModel();
            answerViewModel.Score = score;
            answerViewModel.Answer = answer;
            answerViewModel.CurrentQuestion = currentQuestion;
            answerViewModel.QuestionCount = questionCount;

            if (answerViewModel.Answer)
            {
                answerViewModel.Score++;
            }

            if (answerViewModel.CurrentQuestion < answerViewModel.QuestionCount)
            {
                QuestionViewModel model = _Service.GetQuestion(answerViewModel.TestId, answerViewModel.CurrentQuestion, out int allQuestionsCount);
                ViewBag.QuestionCount = allQuestionsCount;
                ViewBag.CurrentQuestion = answerViewModel.CurrentQuestion + 1;
                ViewBag.Score = answerViewModel.Score;
                return View("Index", model);
            }
            else
            {
                return View("Score", answerViewModel.Score);
            }
        }

        public ActionResult Score()
        {
            return View();
        }
    }
}