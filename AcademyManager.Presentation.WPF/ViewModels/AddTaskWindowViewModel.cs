using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class AddTaskWindowViewModel: BaseViewModel
    {
        public AddTaskWindowViewModel(Teacher teacher, IEducationMaterialsManager materialsManager, IEducationTasksManager tasksManager)
        {
            Materials = new ObservableCollection<EducationMaterial>(materialsManager.Select(teacher));
            Questions = new ObservableCollection<QuestionViewModel>();
            AddQuestion = new DelegateCommand(() => Questions.Add(new QuestionViewModel()));
            Save = new DelegateCommand(() => {
                tasksManager.Insert(new EducationTask(tasksManager.Id(teacher), SelectedMaterial, Questions.Select(i => new TaskQuestion(i.Question, i.Correct, i.UnCorrect)).ToList()));
                ViewService.Message("Контрольная работа сохранена"); 
            });

        }
        public EducationMaterial SelectedMaterial { get; set; }
        public ObservableCollection<EducationMaterial> Materials { get; }
        public ObservableCollection<QuestionViewModel> Questions { get; }
        public ICommand AddQuestion { get; }
        public ICommand Save { get; }
    }
}
