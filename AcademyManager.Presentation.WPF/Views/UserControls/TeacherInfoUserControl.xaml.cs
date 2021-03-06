﻿using System;
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
    /// Interaction logic for TeacherInfoUserControl.xaml
    /// </summary>
    public partial class TeacherInfoUserControl : UserControl
    {
        public TeacherInfoUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext != null && DataContext is TeacherInfoViewModel) {
                ((TeacherInfoViewModel)DataContext).StudentDetails.Execute(null);
            }
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_Click(this, e);
            ((ListView)e.Source).UnselectAll();
        }
    }
}
