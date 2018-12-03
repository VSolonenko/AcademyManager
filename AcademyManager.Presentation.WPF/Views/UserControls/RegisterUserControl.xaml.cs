using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using AcademyManager.Presentation.WPF.ViewModels;

namespace AcademyManager.Presentation.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>

    [ViewFor(typeof(RegisterWindowViewModel))]
    partial class RegisterUserControl : WindowView, IRepeatedPassword
    {
        public RegisterUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler PasswordUpdated;

        public bool Check() => Password.Password.Trim() != "" && RepeatedPassword.Password.Trim() != "" && Password.Password.Trim() == RepeatedPassword.Password.Trim();
        public string GetPassword() => Password.Password.Trim();

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
