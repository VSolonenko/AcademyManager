using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Users
{
    [Serializable]
    public class Student : User
    {
        private readonly Role _role;
        public Student(string name, string lastname):this(name, lastname, new List<Teacher>())
        {

        }
        public Student(string name, string lastname, IEnumerable<Teacher> teachers): base(name, lastname)
        {
            _role = new Role("student");
            Teachers = teachers.ToList();
        }
        public override Role Role => _role;
        public ICollection<Teacher> Teachers { get; }
        public override bool Equals(object obj)
        {
            var isEqual = false;
           
            if (obj is Student) {
                var foo = (Student)obj;
                if (base.Equals(obj)) {
                    isEqual = base.Equals(obj);
                }
                else if (foo.Name == Name && foo.LastName == LastName) {
                    isEqual = true;
                }
            }
            return isEqual;
        }
        public override int GetHashCode()
        {
            var hashCode = -1505215937;
            hashCode = hashCode * -1521134295 + EqualityComparer<Role>.Default.GetHashCode(_role);
            hashCode = hashCode * -1521134295 + EqualityComparer<Role>.Default.GetHashCode(Role);
            return hashCode;
        }
    }
}
