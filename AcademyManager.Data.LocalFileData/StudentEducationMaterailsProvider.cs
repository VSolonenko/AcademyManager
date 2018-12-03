using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Data.LocalFileData
{
    class StudentEducationMaterailsProvider : BaseProvider<StudentEducationMaterial>, IStudentEducationMaterailsProvider
    {
        public StudentEducationMaterailsProvider(string path):base(path, "studentsmaterails.bin")
        {

        }
        protected override bool Compare(StudentEducationMaterial first, StudentEducationMaterial second) => first.Student.Equals(second.Student) && first.Owner.Equals(second.Owner) && first.Theme.Trim() == second.Theme.Trim();
    }
}
