using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.Models.Users;
using AcademyManager.Business.UsersManager;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class AddStudentWindowViewModel: BaseViewModel
    {
        public AddStudentWindowViewModel(Teacher teacher, IStudentsManager studentsManager, ITeachersManager teachersManager)
        {
            StudentsList = new ObservableCollection<Student>(studentsManager.Dettached(teacher));
            AddedStudents = new ObservableCollection<Student>(studentsManager.Attached(teacher));
            RemoveStudent = new DelegateCommand(() => {
                if (SelectedStudentInAdded != null) {
                    StudentsList.Add(SelectedStudentInAdded);
                    AddedStudents.Remove(SelectedStudentInAdded);
                }
            });
            AddStudent = new DelegateCommand(() => {
                if (SelectedStudent != null) {
                    AddedStudents.Add(SelectedStudent);
                    StudentsList.Remove(SelectedStudent);
                }
            });
            Save = new DelegateCommand(() => {
                teachersManager.Update(new Teacher(teacher.Name, teacher.LastName, teacher.Subject, AddedStudents));
                ViewService.Message("Изменения сохранены");
            });
        }
        public ObservableCollection<Student> StudentsList { get; }
        public ObservableCollection<Student> AddedStudents { get; }
        public Student SelectedStudent { get; set; }
        public Student SelectedStudentInAdded { get; set; }
        public ICommand RemoveStudent { get; }
        public ICommand AddStudent { get; }
        public ICommand Save { get; }
    }
}
