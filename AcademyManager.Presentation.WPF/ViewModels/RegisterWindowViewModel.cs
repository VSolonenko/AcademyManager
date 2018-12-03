using AcademyManager.Business.Models;
using AcademyManager.Business.UsersManager;
using AcademyManager.Presentation.WPF.Common.MVVM;
using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class RegisterWindowValidator
    {
        public Tuple<bool, IEnumerable<string>> IsValid(RegisterWindowViewModel registerWindow, IRepeatedPassword view)
        {
            var isValid = true;
            var errors = new List<string>();
            if(registerWindow.Name.Trim() == "") {
                isValid = false;
                errors.Add(@"Поле 'Имя' не может быть пустым");
            }
            if (registerWindow.LastName.Trim() == "") {
                isValid = false;
                errors.Add(@"Поле 'Фамилия' не может быть пустым");
            }
            if (!view.Check()) {
                isValid = false;
                errors.Add(@"Поле 'Пароль' и 'Повторите пароль' не совпадают");
            }
            return Tuple.Create(isValid, (IEnumerable<string>)errors);
        }
    }
    class RegisterWindowViewModel : BaseViewModel
    {
        private string _name = "";
        private string _lastName = "";
        private readonly DelegateCommand _register;
        private readonly RegisterWindowValidator _validator;
        public RegisterWindowViewModel(IRegisterManager registerManager)
        {
            _validator = new RegisterWindowValidator();
            _register = new DelegateCommand(async () => {
                if(ViewService.GetIfOpened(out var view, this)) {
                    var tuple = _validator.IsValid(this, (IRepeatedPassword)view);
                    if (tuple.Item1) {
                        if(registerManager.Register(new RegisterInfo(Name, LastName, ((IRepeatedPassword)view).GetPassword(), "student"))) {
                            ViewService.Message("Регистрация прошла успешно");
                        }
                        else {
                            ViewService.MessageError("Ошибка при регистрации", "RegError");
                        }
                    }
                    else {
                        var strBuilder = new StringBuilder("Форма не прошла валидацию:\n");
                        foreach(var str in tuple.Item2) {
                            strBuilder.Append(str + '\n');
                        }
                        ViewService.MessageError(strBuilder.ToString(), "RegError");
                    }
                }
            });
        }
        public string Name {
            get => _name;
            set {
                SetProperty(ref _name, value);
                _register?.CanExecuteStateChanged();
            }
        }
        public string LastName {
            get => _lastName;
            set {
                SetProperty(ref _lastName, value);
                _register?.CanExecuteStateChanged();
            }
        }
        public ICommand Register => _register;
    }
}
