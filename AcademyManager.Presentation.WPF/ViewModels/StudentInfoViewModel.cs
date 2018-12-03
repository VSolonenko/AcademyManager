using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class StudentInfoViewModel : BaseViewModel
    {
        private readonly Student _student;

        public StudentInfoViewModel(Student student, IViewModelsFactory factory, IEducationMaterialsManager materialsManager, IEducationTasksManager tasksManager)
        {
            _student = student;
            Materials = new ObservableCollection<StudentEducationMaterial>(materialsManager.Select(student));
            Tasks = new ObservableCollection<StudentEducationTask>(tasksManager.Select(student));
            OpenMaterialDetails = new DelegateCommand(() => {
                if (SelectedMaterial != null) {
                    ViewService.CreateView(factory.MaterialDetailsWindowViewModel(SelectedMaterial)).ShowDialog();
                }
            });
            OpenTaskDetails = new DelegateCommand(() => {
                if (SelectedTask != null) {
                    ViewService.CreateView(factory.TaskDetailsWindowViewModel(SelectedTask)).ShowDialog();
                }
            });
        }
        public ICommand OpenMaterialDetails { get; }
        public ICommand OpenTaskDetails { get; }
        public StudentEducationMaterial SelectedMaterial { get; set; }
        public StudentEducationTask SelectedTask { get; set; }
        public ObservableCollection<StudentEducationMaterial> Materials { get; }
        public ObservableCollection<StudentEducationTask> Tasks { get; }
    }
}
