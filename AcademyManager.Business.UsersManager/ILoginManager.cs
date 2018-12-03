using AcademyManager.Business.Models;
using AcademyManager.Business.Models.Users;
using System.Threading.Tasks;

namespace AcademyManager.Business.UsersManager
{
    public interface ILoginManager
    {
        User LoginAsync(LoginInfo loginInfo);
    }
}
