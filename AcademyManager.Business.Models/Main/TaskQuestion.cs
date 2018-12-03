using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class TaskQuestion
    {
        private readonly string _correct;
        private readonly string _noCorrect;

        public TaskQuestion(string question, string correct, string noCorrect)
        {
            Question = question;
            _correct = correct;
            _noCorrect = noCorrect;
            Answers = new List<string> { correct, noCorrect };
        }
        public string Question { get; }
        public ICollection<string> Answers { get; }

        public string Correct => _correct;

        public string NoCorrect => _noCorrect;

        public bool IsCorrect(string answer) => answer != null && Correct.Trim() == answer.Trim();
    }
}
