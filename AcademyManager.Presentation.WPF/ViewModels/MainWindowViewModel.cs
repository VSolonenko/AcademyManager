using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;
using System;
using System.Windows.Input;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        private User _user;
        private string _userName;
        private BaseViewModel _current;

        public MainWindowViewModel(IViewModelsFactory factory)
        {

            OpenLoginWindow = new DelegateCommand(() => {
                var vm = factory.LoginWindowViewModel();
                vm.Loggined += (sender, e) => {
                    var role = e.Role.Type == "teacher" ? "Преподаватель" : "Студент";
                    UserName = $"{role}: {e.Name} {e.LastName}";
                    _user = e;
                    Loggined?.Invoke(this, EventArgs.Empty);
                    if (e.Role.Type.Trim() == "teacher") {
                        Current = factory.TeacherInfoViewModel((Teacher)e);
                    }
                    else {
                        Current = factory.StudentInfoViewModel((Student)e);
                    }
                };
                ViewService.CreateView(vm).ShowDialog();
            });
            OpenRegisterWindow = new DelegateCommand(() => ViewService.CreateView(factory.RegisterWindowViewModel()).ShowDialog());
            OpenAddMaterailWindow = new DelegateCommand(() => {
                if (_user != null && _user is Teacher) {
                    ViewService.CreateView(factory.AddMaterialWindowViewModel((Teacher)_user)).ShowDialog();
                }
            });
            OpenAddTaskWindow = new DelegateCommand(() => {
                if (_user != null && _user is Teacher) {
                    ViewService.CreateView(factory.AddTaskWindowViewModel((Teacher)_user)).ShowDialog();
                }
            });
            OpenAddStudentWindow = new DelegateCommand(() => {
                if (_user != null && _user is Teacher) {
                    ViewService.CreateView(factory.AddStudentWindowViewModel((Teacher)_user)).ShowDialog();
                }
            });
            Logout = new DelegateCommand(() => {
                _user = null;
                Current = null;
                Logouted?.Invoke(this, EventArgs.Empty);
            });
        }
        public ICommand OpenLoginWindow { get; }
        public ICommand OpenRegisterWindow { get; }
        public ICommand OpenAddMaterailWindow { get; }
        public ICommand OpenAddTaskWindow { get; }
        public ICommand OpenAddStudentWindow { get; }
        public ICommand Logout { get; }
        public string UserName { get => _userName; private set => SetProperty(ref _userName, value); }
        public event EventHandler Loggined;
        public event EventHandler Logouted;
        public string Role => _user.Role.Type;
        public BaseViewModel Current { get => _current; set => SetProperty(ref _current, value); }
    }
}
