using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using AcademyManager.Presentation.WPF.ViewModels;
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

namespace AcademyManager.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [ViewFor(typeof(MainWindowViewModel))]
    partial class MainWindow : WindowView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContextChanged += (sender, e) => {
                var vm = (MainWindowViewModel)e.NewValue;
                vm.Loggined += (foo, arg) => {
                    LogRegStackPanel.Visibility = Visibility.Hidden;
                    MPanel.Visibility = Visibility.Visible;
                    if (vm.Role == "teacher") {
                        TPanel.Visibility = Visibility.Visible;
                    }
                };
                vm.Logouted += (bar, ar) => {
                    LogRegStackPanel.Visibility = Visibility.Visible;
                    MPanel.Visibility = Visibility.Hidden;
                    TPanel.Visibility = Visibility.Hidden;
                };
            };
        }

    }
}
