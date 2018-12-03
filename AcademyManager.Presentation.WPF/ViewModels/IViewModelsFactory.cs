using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    interface IViewModelsFactory
    {
        MainWindowViewModel MainWindowViewModel();
        LoginWindowViewModel LoginWindowViewModel();
        RegisterWindowViewModel RegisterWindowViewModel();
        AddMaterialWindowViewModel AddMaterialWindowViewModel(Teacher teacher);
        AddTaskWindowViewModel AddTaskWindowViewModel(Teacher teacher);
        AddStudentWindowViewModel AddStudentWindowViewModel(Teacher teacher);
        TeacherInfoViewModel TeacherInfoViewModel(Teacher teacher);
        StudentDetailsWindowViewModel StudentDetailsWindowViewModel(Student student, Teacher teacher);
        StudentInfoViewModel StudentInfoViewModel(Student student);
        TaskDetailsWindowViewModel TaskDetailsWindowViewModel(StudentEducationTask task);
        MaterialDetailsWindowViewModel MaterialDetailsWindowViewModel(StudentEducationMaterial material);
    }
}
