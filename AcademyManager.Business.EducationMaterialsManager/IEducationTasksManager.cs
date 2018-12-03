using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.EducationMaterialsManager
{
    public interface IEducationTasksManager
    {
        void Insert(EducationTask task);
        void Insert(StudentEducationTask educationTask);
        IEnumerable<EducationTask> Select(Teacher teacher);
        int Id(Teacher teacher);
        IEnumerable<StudentEducationTask> Select(Student student);
        IEnumerable<StudentEducationTask> Select(Student student, Teacher teacher);
    }
}
