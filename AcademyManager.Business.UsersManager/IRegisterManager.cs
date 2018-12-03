using AcademyManager.Business.Models;
using System.Threading.Tasks;

namespace AcademyManager.Business.UsersManager
{
    public interface IRegisterManager
    {
        bool Register(RegisterInfo registerInfo);
    }
}
