using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class StudentMaterialPartViewModel: BaseViewModel
    {
        private readonly SerializableKeyValuePair<EducationMaterialPart, bool> _part;
        private readonly SolidColorBrush _trueColor;
        private readonly SolidColorBrush _falseColor;

        public StudentMaterialPartViewModel(SerializableKeyValuePair<EducationMaterialPart, bool> part, SolidColorBrush trueColor, SolidColorBrush falseColor)
        {
            _part = part;
            _trueColor = trueColor;
            _falseColor = falseColor;
        }
        public string Theme => _part.Key.Theme;
        public string IsCompleted => _part.Value ? "\u2714" : "\u2718";
        public SolidColorBrush StatusColor => _part.Value ? _trueColor : _falseColor;
    }

    class StudentMaterialViewModel: BaseViewModel
    {
        private readonly StudentEducationMaterial _material;
        private readonly SolidColorBrush _true;
        private readonly SolidColorBrush _false;
        public StudentMaterialViewModel(StudentEducationMaterial material)
        {
            _true = new SolidColorBrush(Colors.LimeGreen);
            _false = new SolidColorBrush(Colors.Red);
            _material = material;
            Parts = new ObservableCollection<StudentMaterialPartViewModel>(material.PartsInfo.Select(i => new StudentMaterialPartViewModel(i, _true, _false)));
        }
        public string Theme => _material.Theme;
        public int SessionsCount => _material.SessionsCount;
        public ObservableCollection<StudentMaterialPartViewModel> Parts { get; }
        public string IsCompleted => _material.IsCompleted ? "\u2714" : "\u2718";
        public StudentEducationMaterial Model() => _material;
        public SolidColorBrush StatusColor => _material.IsCompleted ? _true : _false;
    }

    class StudentTaskViewModel: BaseViewModel
    {
        private readonly StudentEducationTask _task;
        private readonly SolidColorBrush _bestMark;
        private readonly SolidColorBrush _goodMark;
        private readonly SolidColorBrush _worsestMark;
        public StudentTaskViewModel(StudentEducationTask task)
        {
            _bestMark = new SolidColorBrush(Colors.LimeGreen);
            _goodMark = new SolidColorBrush(Colors.Orange);
            _worsestMark = new SolidColorBrush(Colors.Red);
            _task = task;
            OpenSolution = new DelegateCommand(() => ViewService.CreateView(new SolutionWindowViewModel(_task)).ShowDialog(), () => _task.IsDone);
        }
        public string Theme => _task.Material.Theme;
        public int TaskNumder => _task.Id;
        public string Mark => _task.Solution?.Mark.ToString() ?? "";
        public ICommand OpenSolution { get; }
        public string IsCompleted => _task.Solution != null ? "\u2714" : "\u2718";
        public SolidColorBrush StatusColor {
            get {
                if(_task.Solution != null) {
                    if(_task.Solution.Mark == 5) {
                        return _bestMark;
                    }
                    else if(_task.Solution.Mark > 2 && _task.Solution.Mark < 5) {
                        return _goodMark;
                    }
                }
                return _worsestMark;
            }
        }

        internal StudentEducationTask Model() => _task;
    }

    class StudentDetailsWindowViewModel: BaseViewModel
    {
        private readonly Student _student;
        private  MaterialsToStudentViewModel _materialsToStudent;
        private  TaskToStudentWindowViewModel _taskToStudent;

        public StudentDetailsWindowViewModel(Student student, Teacher teacher, IEducationMaterialsManager educationMaterialsManager, IEducationTasksManager tasksManager)
        {
           
            
            Materials = new ObservableCollection<StudentMaterialViewModel>(educationMaterialsManager.Select(student).Select(i => new StudentMaterialViewModel(i)));
            Tasks = new ObservableCollection<StudentTaskViewModel>(tasksManager.Select(student).Select(i => new StudentTaskViewModel(i)));
            AddMaterials = new DelegateCommand(() => {
                _materialsToStudent = new MaterialsToStudentViewModel(educationMaterialsManager.Select(teacher).Select(i => new MaterialSelectorItem(i, Materials.Any(j =>j.Model().Owner.Equals(i.Owner) && j.Theme == i.Theme))));
                _materialsToStudent.ItemsChanged += (sender, e) => {
                    foreach(var foo in _materialsToStudent.Materials.Where(i => i.IsSelected).Where(i => !Materials.Any(j => j.Equals(i)))) {
                        Materials.Add(new StudentMaterialViewModel(new StudentEducationMaterial(student, foo.EducationMaterial)));
                    }
                };
                ViewService.CreateView(_materialsToStudent).ShowDialog();
            });
            AddTasks = new DelegateCommand(() => {
                _taskToStudent = new TaskToStudentWindowViewModel(tasksManager.Select(teacher).Select(i => new TaskSelectorItem(i, Tasks.Any(j => j.TaskNumder == i.Id))));
                _taskToStudent.ItemsChanged += (sender, e) => {
                    foreach(var task in _taskToStudent.Tasks.Where(i => i.IsSelected).Where(i => !Tasks.Any(j => j.TaskNumder == i.Task.Id))) {
                        Tasks.Add(new StudentTaskViewModel(new StudentEducationTask(student, task.Task)));
                    }
                };
                ViewService.CreateView(_taskToStudent).ShowDialog();
            });
            Save = new DelegateCommand(() => {
                foreach(var material in Materials.Select(i => i.Model())) {
                    educationMaterialsManager.Insert(material);
                }
                foreach(var task in Tasks) {
                    tasksManager.Insert(task.Model());
                }
                ViewService.Message("Изменения сохранены");
            });
            _student = student;
        } 
        public string Name => _student.Name;
        public string LastName => _student.LastName;
        public ObservableCollection<StudentMaterialViewModel> Materials { get; }
        public ObservableCollection<StudentTaskViewModel> Tasks { get; }
        public ICommand Save { get; }
        public ICommand AddMaterials { get; }
        public ICommand AddTasks { get; }
    }
}
