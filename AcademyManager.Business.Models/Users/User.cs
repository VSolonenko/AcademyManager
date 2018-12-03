using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Users
{
    [Serializable]
    public abstract class User
    {
        public User(string name, string lastname)
        {
            Name = name;
            LastName = lastname;
        }
        public string Name { get; }
        public string LastName { get; }
        public abstract Role Role { get; }
        public override bool Equals(object obj)
        {
            var isEqual = false;
            var foo = (User)obj;
            if (obj is User) {

                if (base.Equals(obj)) {
                    isEqual = base.Equals(obj);
                }
                else if (foo.Name == Name && foo.LastName == LastName) {
                    isEqual = true;
                }
            }
            return isEqual;
        }
    }
}
