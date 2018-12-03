using System;


namespace AcademyManager.Presentation.WPF.Common.MVVM
{
    class DelegateCommand<T> : Command<T>
    {
        private readonly Action<T> _executeMethod;
        private readonly Func<bool> _canExecuteMethod;

        public DelegateCommand(Action<T> executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public DelegateCommand(Action<T> executeMethod):this(executeMethod, () => true)
        {

        }
        public override bool CanExecute() => _canExecuteMethod();
        public override void Execute(T param) => _executeMethod(param);
    }
    class DelegateCommand : Command
    {
        private readonly Action _executeMethod;
        private readonly Func<bool> _canExecuteMethod;

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public DelegateCommand(Action executeMethod):this(executeMethod, () => true)
        {

        }
        public override bool CanExecute() => _canExecuteMethod();
        public override void Execute() => _executeMethod();
    }

}
