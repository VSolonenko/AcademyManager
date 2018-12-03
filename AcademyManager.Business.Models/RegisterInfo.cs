using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models
{
    public class RegisterInfo
    {
        public RegisterInfo(string name, string lastname, string password, string role)
        {
            Name = name;
            LastName = lastname;
            Password = password;
            Role = role;
        }
        public string Name { get; }
        public string LastName { get; }
        public string Password { get; }
        public string Role { get; }
    }
}
