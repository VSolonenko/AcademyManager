using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Data
{
    public interface IUsersProvider: IRepository<User>
    {
    }
}
