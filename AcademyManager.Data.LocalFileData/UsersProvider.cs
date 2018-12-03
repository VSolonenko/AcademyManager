using AcademyManager.Business.Models.Users;

namespace AcademyManager.Data.LocalFileData
{
    class UsersProvider : BaseProvider<User>, IUsersProvider
    {
        public UsersProvider(string path) : base(path, "users.bin")
        {

        }

        protected override bool Compare(User first, User second)
        {
            if(first.Name == second.Name && first.Name == second.Name && first.Role.Type == second.Role.Type) {
                return true;
            }
            return false;
        }
        protected override void Seed()
        {
            Create(new Teacher("Иван", "Иванов", new Business.Models.Main.EducationSubject("C++")));
            Create(new Student("Петр", "Петров"));
            Create(new Student("Антон", "Сидоров"));
            Create(new Student("Егор", "Власов"));
        }
    }
}
