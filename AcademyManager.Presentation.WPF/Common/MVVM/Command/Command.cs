using System;
using System.Windows.Input;

namespace AcademyManager.Presentation.WPF.Common.MVVM
{
    abstract class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter) => CanExecute();
        void ICommand.Execute(object parameter) => Execute((T)parameter);
        public abstract bool CanExecute();
        public abstract void Execute(T param);
        public void CanExecuteStateChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        bool ICommand.CanExecute(object parameter) => CanExecute();
        void ICommand.Execute(object parameter) => Execute();
        public abstract bool CanExecute();
        public abstract void Execute();
        public void CanExecuteStateChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
