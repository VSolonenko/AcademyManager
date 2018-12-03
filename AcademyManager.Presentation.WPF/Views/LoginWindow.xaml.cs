using System;
using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using AcademyManager.Presentation.WPF.ViewModels;



namespace AcademyManager.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    [ViewFor(typeof(LoginWindowViewModel))]
    partial class LoginWindow : WindowView, IPasswordHandler
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public event EventHandler PasswordUpdated;

        public string GetPassword()
        {
            var result = Password.Password;
            return result;
        }


        private void Password_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
