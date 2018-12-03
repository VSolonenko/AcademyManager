using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AcademyManager.Business.Models.Main;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class AnswerViewModel: BaseViewModel
    {
        private readonly KeyValuePair<TaskQuestion, bool> _answer;
        private readonly SolidColorBrush _correct;
        private readonly SolidColorBrush _incorrect;
        public AnswerViewModel(KeyValuePair<TaskQuestion, bool> answer)
        {
            _correct = new SolidColorBrush(Colors.Lime);
            _incorrect = new SolidColorBrush(Colors.Red);
            _answer = answer;
        }
        public string Content => _answer.Key.Question;
        public string CorrectAnswer => _answer.Key.Correct;
        public string InCorrectAnswer => _answer.Key.NoCorrect;
        public SolidColorBrush IsCorrect => _answer.Value ? _correct : _incorrect;
    }
    class SolutionWindowViewModel: BaseViewModel
    {
        private readonly StudentEducationTask _task;

        public SolutionWindowViewModel(StudentEducationTask task)
        {
            _task = task;
            Answers = new List<AnswerViewModel>(_task.Solution.Questions.Select(i => new AnswerViewModel(i)));
        }
        public string StudentName => $"{_task.Student.LastName} {_task.Student.Name}";
        public int TaskNumber => _task.Id;
        public string Theme => _task.Material.Theme;
        public int Mark => _task.Solution.Mark;
        public IEnumerable<AnswerViewModel> Answers { get; }
    }
}
