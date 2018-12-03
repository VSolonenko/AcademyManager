using AcademyManager.Business.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Users
{
    [Serializable]
    public class Teacher : User
    {
        private readonly Role _role;
        public Teacher(string name, string lastname, EducationSubject subject) : this(name, lastname, subject, 
            new List<Student>())
        {

        }
        public Teacher(string name, string lastname, EducationSubject subject, 
            IEnumerable<Student> students) : base(name, lastname)
        {
            
            _role = new Role("teacher");
            Subject = subject;
            Students = students.ToList();
        }
        public override Role Role => _role;
        public ICollection<Student> Students { get; }
        public EducationSubject Subject { get; }
        public override bool Equals(object obj)
        {
            var isEqual = false;
          
            if (obj is Teacher) {
                var foo = (Teacher)obj;
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
            var hashCode = -439156529;
            hashCode = hashCode * -1521134295 + EqualityComparer<Role>.Default.GetHashCode(_role);
            hashCode = hashCode * -1521134295 + EqualityComparer<Role>.Default.GetHashCode(Role);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<Student>>.Default.GetHashCode(Students);
            hashCode = hashCode * -1521134295 + EqualityComparer<EducationSubject>.Default.GetHashCode(Subject);
            return hashCode;
        }
    }
}
