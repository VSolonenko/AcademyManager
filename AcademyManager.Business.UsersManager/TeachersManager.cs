using System.Linq;
using AcademyManager.Business.Models.Users;
using AcademyManager.Data;

namespace AcademyManager.Business.UsersManager
{
    class TeachersManager : ITeachersManager
    {
        private readonly IUsersProvider _usersProvider;

        public TeachersManager(IUsersProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }
        public void Update(Teacher teacher)
        {
            _usersProvider.Update(teacher);
            if (teacher.Students.Count > 0) {
                foreach(var student in teacher.Students) {
                    if(!student.Teachers.Any(i => i.Equals(teacher))) {
                        student.Teachers.Add(teacher);
                        _usersProvider.Update(student);
                    }
                }
            }
        }
    }
}
