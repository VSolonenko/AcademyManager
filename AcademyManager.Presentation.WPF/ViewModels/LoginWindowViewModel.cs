using AcademyManager.Business.Models.Users;
using AcademyManager.Business.UsersManager;
using AcademyManager.Presentation.WPF.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class LoginWindowViewModel : BaseViewModel
    {
        private string _name;
        private string _lastName;
        private readonly DelegateCommand _login;
        private bool _handled;
        public LoginWindowViewModel(ILoginManager loginManager)
        {

            _login = new DelegateCommand(() => {
                if (ViewService.GetIfOpened(out var view, this)) {
                    User user = loginManager.LoginAsync(new Business.Models.LoginInfo(Name, LastName, ViewService.GetPasswordHandler(view).GetPassword()));
                    if (user != null) {
                        Loggined?.Invoke(this, user);
                        view.Close();
                    }
                    else {
                        ViewService.MessageError("Пользователь не найден", "loginError");
                    }
                }

            },
            () => {
                if (ViewService.GetIfOpened(out var view, this)) {
                    var _pHandler = ViewService.GetPasswordHandler(view);
                    if (!_handled) {
                        _pHandler.PasswordUpdated += (sender, e) => _login?.CanExecuteStateChanged();
                        _handled = true;
                    }
                   
                    var password = _pHandler.GetPassword();
                    if (Name?.Trim() != "" && LastName?.Trim() != "" && password != "") {
                        return true;
                    }
                }
                return false;
            });
        }
        public string Name {
            get => _name;
            set {
                SetProperty(ref _name, value);
                _login?.CanExecuteStateChanged();
            }
        }
        public string LastName {
            get => _lastName;
            set {
                SetProperty(ref _lastName, value);
                _login?.CanExecuteStateChanged();
            }
        }



        public ICommand Login => _login;
        public event EventHandler<User> Loggined;
    }
}
