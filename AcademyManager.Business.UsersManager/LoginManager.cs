using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models;
using AcademyManager.Business.Models.Users;
using AcademyManager.Data;

namespace AcademyManager.Business.UsersManager
{
    class LoginManager : ILoginManager
    {
        private readonly IUsersProvider _usersProvider;
        private readonly ILoginInfoesProvider _loginInfoesProvider;

        public LoginManager(IUsersProvider usersProvider, ILoginInfoesProvider loginInfoesProvider)
        {
            _usersProvider = usersProvider;
            _loginInfoesProvider = loginInfoesProvider;
        }
        public User LoginAsync(LoginInfo loginInfo)
        {
            if (_loginInfoesProvider.Select().Any(i => i.Name == loginInfo.Name.Trim() && i.LastName == loginInfo.LastName.Trim() && i.Password == loginInfo.Password.Trim())) {
                return _usersProvider.Select().FirstOrDefault(i => i.Name == loginInfo.Name.Trim() && i.LastName == loginInfo.LastName.Trim());
            }
            return null;
        }

    }
}
