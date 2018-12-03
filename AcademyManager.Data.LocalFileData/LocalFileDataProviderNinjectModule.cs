using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace AcademyManager.Data.LocalFileData
{
    public class LocalFileDataProviderNinjectModule : NinjectModule
    {
        private readonly string _path = "Data";
        public override void Load()
        {
            Bind<IProvidersFactory>().To<ProvidersFactory>().InSingletonScope();
            Bind<IUsersProvider>().ToConstant(new UsersProvider(_path)).InSingletonScope();
            Bind<ILoginInfoesProvider>().ToConstant(new LoginInfoProvider(_path)).InSingletonScope();
            Bind<IEducationMaterailsProvider>().ToConstant(new MaterialsProvider(_path)).InSingletonScope();
            Bind<IEducationTasksProvider>().ToConstant(new EducationTasksProvider(_path)).InSingletonScope();
            Bind<IStudentEducationMaterailsProvider>().ToConstant(new StudentEducationMaterailsProvider(_path)).InSingletonScope();
            Bind<IStudentEducationTaskProvider>().ToConstant(new StudentEducationTasksProvider(_path)).InSingletonScope();

        }
    }
}
