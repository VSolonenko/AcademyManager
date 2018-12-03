using AcademyManager.Presentation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AcademyManager.Presentation.WPF.Common.MVVM.ViewService
{
   
    class WindowView : Window, IView
    {
        void IView.ShowDialog()
        {
            Dispatcher.Invoke(() => ShowDialog());
        }
    }
}
