using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models
{
    [Serializable]
    public class LoginInfo
    {
        public LoginInfo(string name, string lastname, string password)
        {
            Name = name;
            LastName = lastname;
            Password = password;
        }
        public string Name { get; }
        public string LastName { get; }
        public string Password { get; }
    }
}
