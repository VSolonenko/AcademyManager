using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class EducationTaskSolution
    {
        public EducationTaskSolution(StudentEducationTask task, 
                                     IEnumerable<KeyValuePair<TaskQuestion, bool>> questions, int mark)
        {
            Task = task;
            Questions = questions;
            Mark = mark;
        }

        public StudentEducationTask Task { get; }
        public IEnumerable<KeyValuePair<TaskQuestion, bool>> Questions { get; }
        public int Mark { get; }
    }
}
