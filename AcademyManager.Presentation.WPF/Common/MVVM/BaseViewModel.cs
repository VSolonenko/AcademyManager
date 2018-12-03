using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AcademyManager.Presentation.WPF.Common.MVVM
{
    abstract class BaseViewModel: INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void SetProperty<TValue>(ref TValue oldValue, TValue newValue, [CallerMemberName]string propertyName = null)
        {
            if (!oldValue?.Equals(newValue) ?? newValue != null)
            {
                oldValue = newValue;
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void UpdateProperty([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected IViewService ViewService { get; }

        public BaseViewModel()
        {
            ViewService = new ViewService.ViewService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

     
    }
}
