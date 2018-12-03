using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Data.LocalFileData
{
    class StudentEducationTasksProvider: BaseProvider<StudentEducationTask>, IStudentEducationTaskProvider
    {
        public StudentEducationTasksProvider(string path):base(path, "studentstasks.bin")
        {

        }

        protected override bool Compare(StudentEducationTask first, StudentEducationTask second) => (first.Student.Equals(second.Student) && first.Id == second.Id) ;
        
    }
}
