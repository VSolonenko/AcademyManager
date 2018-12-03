using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models.Main;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class QuestionSelectorViewModel
    {
        private readonly TaskQuestion _question;
        public QuestionSelectorViewModel(TaskQuestion question, Random random)
        {
            _question = question;
            if (random.Next(1000) > 500) {
                FirstVariant = question.Answers.First();
                SecondVariant = question.Answers.Last();
            }
            else {
                SecondVariant = question.Answers.First();
                FirstVariant = question.Answers.Last();
            }

        }
        public string FirstVariant { get; }
        public string SecondVariant { get; }
        public string CurrentAnswer { get; set; }
        public bool IsFirst { get; set; }
        public bool IsSecond { get; set; }
        public string Question => Question1.Question;

        public TaskQuestion Question1 => _question;

        public void Check()
        {
            if (CurrentAnswer == FirstVariant) {
                IsFirst = true;
                IsSecond = false;
            }
            else if (CurrentAnswer == SecondVariant) {
                IsSecond = true;
                IsFirst = false;
            }
            else {
                IsSecond = false;
                IsFirst = false;
            }
        }
    }
    class TaskDetailsWindowViewModel : BaseViewModel
    {
        private readonly DelegateCommand _prev;
        private readonly DelegateCommand _next;
        private Random _random;
        private QuestionSelectorViewModel _currentQuestion;
        private int _currentQuestionNumber;

        public TaskDetailsWindowViewModel(StudentEducationTask task, IEducationTasksManager tasksManager, IEducationTaskExaminationManager examination)
        {
            Theme = task.Material.Theme;
            _random = new Random();
            Questions = new ObservableCollection<QuestionSelectorViewModel>(task.Questions.Select(i => new QuestionSelectorViewModel(i, _random)));
            CurrentQuestion = Questions.First();
            _prev = new DelegateCommand(() => {
                var index = Questions.IndexOf(CurrentQuestion);
                if (index > 0) {
                    CurrentQuestion.Check();
                    CurrentQuestion = Questions[--index];
                    CurrentQuestionNumber = ++index;
                }
            }, () => CurrentQuestionNumber - 1 > 0);
            _next = new DelegateCommand(() => {
                var index = Questions.IndexOf(CurrentQuestion);
                if (index < Questions.Count - 1) {
                    CurrentQuestion.Check();
                    CurrentQuestion = Questions[++index];
                    CurrentQuestionNumber = ++index;
                }
            }, () => CurrentQuestionNumber - 1 < Questions.Count - 1);
            Finish = new DelegateCommand(() => {
                var result = examination.Examine(task, Questions.Select(i => new KeyValuePair<TaskQuestion, string>(task.Questions.FirstOrDefault(j => j.Question.Trim() == i.Question.Trim()), i.CurrentAnswer)));
                tasksManager.Insert(result);
                if(ViewService.GetIfOpened(out var view, this)) {
                    view.Close();
                    ViewService.Message($"Ваша оценка {result.Solution.Mark}");
                }
            });
            SelectAnswer = new DelegateCommand<string>((param) => CurrentQuestion.CurrentAnswer = param);
            CurrentQuestionNumber = 1;
        }
        public string Theme { get; }
        public int CurrentQuestionNumber {
            get => _currentQuestionNumber;
            set {
                SetProperty(ref _currentQuestionNumber, value);
                _prev.CanExecuteStateChanged();
                _next.CanExecuteStateChanged();
            }
        }
        public QuestionSelectorViewModel CurrentQuestion { get => _currentQuestion; set => SetProperty(ref _currentQuestion, value); }
        public ObservableCollection<QuestionSelectorViewModel> Questions { get; }
        public ICommand Next => _next;
        public ICommand Prev => _prev;
        public ICommand SelectAnswer { get; }
        public ICommand Finish { get; }
    }
}
