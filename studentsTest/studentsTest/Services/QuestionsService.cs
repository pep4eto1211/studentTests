using studentsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentsTest.Services
{
    public class QuestionsService
    {
        public QuestionViewModel GetQuestion(int testId, int questionIndex, out int allQuestionsCount)
        {
            List<QuestionViewModel> questions = new List<QuestionViewModel>();
            for (int i = 0; i < 10; i++)
            {
                QuestionViewModel question = new QuestionViewModel();
                question.Text = $"Which is the correct answer ({i.ToString()})?";
                question.PossibleAnswers = new List<string>();
                for (int j = 0; j < 6; j++)
                {
                    question.PossibleAnswers.Add($"Option {j.ToString()}");
                }
                question.CorrectAnswerIndex = 3;
                question.QuestionId = i;

                questions.Add(question);
            }

            allQuestionsCount = questions.Count;
            return questions[questionIndex];
        }
    }
}
