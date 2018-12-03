using AcademyManager.Business.Models;

namespace AcademyManager.Data.LocalFileData
{
    class LoginInfoProvider : BaseProvider<LoginInfo>, ILoginInfoesProvider
    {
        public LoginInfoProvider(string path): base(path, "loginInfoes.bin")
        {

        }

        protected override bool Compare(LoginInfo first, LoginInfo second)
        {
            if(first.Name == second.Name && first.LastName == second.LastName && first.Password == second.Password) {
                return true;
            }
            return false;
        }

        protected override void Seed()
        {
            Create(new LoginInfo("Иван", "Иванов", "admin"));
        }
    }
}
