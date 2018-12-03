using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Business.UsersManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class ViewModelsFactory : IViewModelsFactory
    {
        private readonly ILoginManager _loginManager;
        private readonly IRegisterManager _registerManager;
        private readonly IEducationMaterialsManager _educationMaterialsManager;
        private readonly IEducationTasksManager _tasksManager;
        private readonly IStudentsManager _studentsManager;
        private readonly ITeachersManager _teachersManager;
        private readonly IEducationTaskExaminationManager _education;

        public ViewModelsFactory(ILoginManager loginManager, IRegisterManager registerManager, 
                                IEducationMaterialsManager educationMaterialsManager, IEducationTasksManager tasksManager,
                                IStudentsManager studentsManager, ITeachersManager teachersManager, IEducationTaskExaminationManager education)
        {
            _loginManager = loginManager;
            _registerManager = registerManager;
            _educationMaterialsManager = educationMaterialsManager;
            _tasksManager = tasksManager;
            _studentsManager = studentsManager;
            _teachersManager = teachersManager;
            _education = education;
        }

        public AddMaterialWindowViewModel AddMaterialWindowViewModel(Teacher teacher) => new AddMaterialWindowViewModel(_educationMaterialsManager, teacher);
        public AddStudentWindowViewModel AddStudentWindowViewModel(Teacher teacher) => new AddStudentWindowViewModel(teacher, _studentsManager, _teachersManager);
        public AddTaskWindowViewModel AddTaskWindowViewModel(Teacher teacher) => new AddTaskWindowViewModel(teacher, _educationMaterialsManager, _tasksManager);
        public LoginWindowViewModel LoginWindowViewModel() => new LoginWindowViewModel(_loginManager);
        public MainWindowViewModel MainWindowViewModel() => new MainWindowViewModel(this);
        public MaterialDetailsWindowViewModel MaterialDetailsWindowViewModel(StudentEducationMaterial material) => new MaterialDetailsWindowViewModel(material, _educationMaterialsManager);
        public RegisterWindowViewModel RegisterWindowViewModel() => new RegisterWindowViewModel(_registerManager);
        public StudentDetailsWindowViewModel StudentDetailsWindowViewModel(Student student, Teacher teacher) => new StudentDetailsWindowViewModel(student, teacher, _educationMaterialsManager, _tasksManager);
        public StudentInfoViewModel StudentInfoViewModel(Student student) => new StudentInfoViewModel(student, this, _educationMaterialsManager, _tasksManager);
        public TaskDetailsWindowViewModel TaskDetailsWindowViewModel(StudentEducationTask task) => new TaskDetailsWindowViewModel(task, _tasksManager, _education);
        public TeacherInfoViewModel TeacherInfoViewModel(Teacher teacher) => new TeacherInfoViewModel(teacher, this);
    }
}
