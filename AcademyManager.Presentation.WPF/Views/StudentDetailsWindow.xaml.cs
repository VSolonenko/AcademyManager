using System.Windows.Controls;
using AcademyManager.Presentation.WPF.Common.MVVM.ViewService;
using AcademyManager.Presentation.WPF.ViewModels;

namespace AcademyManager.Presentation.WPF.Views
{
    /// <summary>
    /// Interaction logic for StudentDetailsWindowViewModel.xaml
    /// </summary>
    [ViewFor(typeof(StudentDetailsWindowViewModel))]
    partial class StudentDetailsWindow : WindowView
    {
        public StudentDetailsWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            List.UnselectAll();
            TaskList.UnselectAll();
            if(e.Source != List) {
                ((ListView)e.Source).UnselectAll();
            }
        }
    }
}
