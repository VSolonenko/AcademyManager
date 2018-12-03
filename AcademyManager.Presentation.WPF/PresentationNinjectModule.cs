using AcademyManager.Presentation.WPF.ViewModels;
using Ninject.Modules;


namespace AcademyManager.Presentation.WPF
{
    class PresentationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewModelsFactory>().To<ViewModelsFactory>().InSingletonScope();
        }
    }
}
