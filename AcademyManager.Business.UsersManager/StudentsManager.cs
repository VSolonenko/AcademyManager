using System;
using System.Collections.Generic;
using System.Linq;
using AcademyManager.Business.Models.Users;
using AcademyManager.Data;

namespace AcademyManager.Business.UsersManager
{
    class StudentsManager : IStudentsManager
    {
        private readonly IUsersProvider _usersProvider;

        public StudentsManager(IUsersProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }
        public IEnumerable<Student> Attached(Teacher teacher)
        {
            var user = _usersProvider.Select().FirstOrDefault(i => i.Equals(teacher));
            if(user != null) {
                return ((Teacher)user).Students;
            }
            return new List<Student>();
        }
        public IEnumerable<Student> Dettached(Teacher teacher) => Select().Cast<Student>().Where(i => !i.Teachers.Any(j => j.Equals(teacher)));
        public IEnumerable<Student> Select() => _usersProvider.Select().Where(i => i is Student).Cast<Student>();
    }
}
