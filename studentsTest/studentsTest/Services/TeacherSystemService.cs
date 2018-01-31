using studentsTest.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using studentsTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings;
using System.Text;

namespace studentsTest.Services
{
    public class TeacherSystemService : ITeacherSystemService
    {
        private const string _URL = "http://192.168.1.6:8080/all-tests";

        private readonly IServiceProvider m_ServiceProvider;
        // note here you ask to the injector for IServiceProvider
        public TeacherSystemService(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            m_ServiceProvider = serviceProvider;
        }

        public void LoadTests()
        {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string json = wc.DownloadString(_URL);
                List<TestEntry> tests = JsonConvert.DeserializeObject<List<TestEntry>>(json);

                if (tests != null)
                {
                    InsertTestsIntoDatabase(tests); 
                }
            }
        }

        private void InsertTestsIntoDatabase(List<TestEntry> tests)
        {
            using (var serviceScope = m_ServiceProvider.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<StudentTestsContext>())
                {
                    foreach (TestEntry item in tests)
                    {
                        Tests newTest = new Tests();
                        newTest.TestName = item.Test.Subject ?? String.Empty;

                        List<Questions> newQuestions = new List<Questions>();
                        foreach (QuestionEntry question in item.Questions)
                        {
                            Questions newQuestion = new Questions();
                            newQuestion.Text = question.Question.Question ?? String.Empty;

                            List<QuestionOptions> options = new List<QuestionOptions>();
                            for (int i = 0; i < question.Answers.Length; i++)
                            {
                                options.Add(new QuestionOptions()
                                {
                                    OptionText = question.Answers[i].Answer ?? String.Empty
                                });

                                if (question.Answers[i].IsCorrect)
                                {
                                    newQuestion.CorrectAnswerIndex = i;
                                }
                            }

                            newQuestion.QuestionOptions = options;
                            newQuestions.Add(newQuestion);
                        }

                        newTest.Questions = newQuestions;

                        context.Database.ExecuteSqlCommand("DELETE FROM Tests");

                        context.Tests.Add(newTest);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
