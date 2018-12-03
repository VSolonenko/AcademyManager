using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.UsersManager;
using AcademyManager.Data.LocalFileData;
using AcademyManager.Presentation.WPF.ViewModels;
using AcademyManager.Presentation.WPF.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AcademyManager.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var kernel = new StandardKernel(new PresentationNinjectModule(), new UsersManagerNinjectModule(), new LocalFileDataProviderNinjectModule(), new EducationMaterialsManagerNinjectModule());
            var window = new MainWindow();
            window.DataContext = kernel.Get<IViewModelsFactory>().MainWindowViewModel();
            window.Show();
        }
    }
}
