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
using System.Windows.Shapes;
using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using AcademyManager.Presentation.WPF.ViewModels;

namespace AcademyManager.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    [ViewFor(typeof(SolutionWindowViewModel))]
    partial class SolutionWindow : WindowView
    {
        public SolutionWindow()
        {
            InitializeComponent();
        }
    }
}
