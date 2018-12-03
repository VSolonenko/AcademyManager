using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Users
{
    [Serializable]
    public class Role
    {
        public Role(string type)
        {
            Type = type;
        }
        public string Type { get; }
    }
}
