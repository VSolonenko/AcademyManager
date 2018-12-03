using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.UsersManager
{
    public interface IStudentsManager
    {
        IEnumerable<Student> Select();
        IEnumerable<Student> Attached(Teacher teacher);
        IEnumerable<Student> Dettached(Teacher teacher);

    }
}
