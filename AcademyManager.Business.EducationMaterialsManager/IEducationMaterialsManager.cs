using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.EducationMaterialsManager
{
    public interface IEducationMaterialsManager
    {
        IEnumerable<EducationMaterial> Select(Teacher teacher);
        IEnumerable<StudentEducationMaterial> Select(Student student);
        void Insert(EducationMaterial educationMaterial);
        void Insert(StudentEducationMaterial educationMaterial); 
    }
}
