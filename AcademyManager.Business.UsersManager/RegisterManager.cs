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
    class RegisterManager : IRegisterManager
    {
        private readonly IUsersProvider _usersProvider;
        private readonly ILoginInfoesProvider _loginInfoesProvider;

        public RegisterManager(IUsersProvider usersProvider, ILoginInfoesProvider loginInfoesProvider)
        {
            _usersProvider = usersProvider;
            _loginInfoesProvider = loginInfoesProvider;
        }
        public bool Register(RegisterInfo registerInfo)
        {
            if(registerInfo.Role == "student") {
                _usersProvider.Create(new Student(registerInfo.Name, registerInfo.LastName));
                _loginInfoesProvider.Create(new LoginInfo(registerInfo.Name, registerInfo.LastName, registerInfo.Password));
                return true;
            }
            return false;
        }
    }
}
