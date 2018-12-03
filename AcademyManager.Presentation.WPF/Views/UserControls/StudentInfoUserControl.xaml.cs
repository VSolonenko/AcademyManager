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
using AcademyManager.Presentation.WPF.ViewModels;

namespace AcademyManager.Presentation.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for StudentInfoUserControl.xaml
    /// </summary>
    public partial class StudentInfoUserControl : UserControl
    {
        public StudentInfoUserControl()
        {
            InitializeComponent();
        }

        private void MaterialButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext != null && DataContext is StudentInfoViewModel) {
                ((StudentInfoViewModel)DataContext).OpenMaterialDetails.Execute(null);
            }
        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext != null && DataContext is StudentInfoViewModel) {
                ((StudentInfoViewModel)DataContext).OpenTaskDetails.Execute(null);
            }
        }

        private void MaterialsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source == MaterialsList) {
                MaterialButton_Click(this, e);
                MaterialsList.UnselectAll();
            }
            else if(e.Source == TasksList) {
                TaskButton_Click(this, e);
                TasksList.UnselectAll();
            }
        }
    }
}
