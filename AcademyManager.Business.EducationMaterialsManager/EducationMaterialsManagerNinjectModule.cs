using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace AcademyManager.Business.EducationMaterialsManager
{
    public class EducationMaterialsManagerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEducationMaterialsManager>().To<MaterialsManager>().InSingletonScope();
            Bind<IEducationTasksManager>().To<EducationTasksManager>().InSingletonScope();
            Bind<IEducationTaskExaminationManager>().To<EducationTaskExamination>().InSingletonScope();
        }
    }
}
