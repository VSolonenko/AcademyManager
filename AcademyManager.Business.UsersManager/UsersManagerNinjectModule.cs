using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.UsersManager
{
    public class UsersManagerNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoginManager>().To<LoginManager>();
            Bind<IRegisterManager>().To<RegisterManager>();
            Bind<IStudentsManager>().To<StudentsManager>();
            Bind<ITeachersManager>().To<TeachersManager>();
        }
    }
}
