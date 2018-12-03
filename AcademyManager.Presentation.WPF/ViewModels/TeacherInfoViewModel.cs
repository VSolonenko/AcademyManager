using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{

    class TeacherInfoViewModel: BaseViewModel
    {
        public TeacherInfoViewModel(Teacher teacher, IViewModelsFactory factory)
        {
            var students = teacher.Students.ToList();
            students.Sort((i, j) => String.Compare(i.LastName, j.LastName));
            Students = new ObservableCollection<Student>(students);
            
            StudentDetails = new DelegateCommand(() => {
                if(SelectedStudent != null) {
                    ViewService.CreateView(factory.StudentDetailsWindowViewModel(SelectedStudent, teacher)).ShowDialog();
                }
            });
        }
        public ObservableCollection<Student> Students { get; }
        public Student SelectedStudent { get; set; }
        public ICommand StudentDetails { get; }
    }
}
