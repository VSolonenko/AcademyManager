using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Business.EducationMaterialsManager
{
    public interface IEducationTaskExaminationManager
    {
        StudentEducationTask Examine(StudentEducationTask task, IEnumerable<KeyValuePair<TaskQuestion, string>> anwers);
    }
}
