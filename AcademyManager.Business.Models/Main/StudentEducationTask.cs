using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class StudentEducationTask: EducationTask
    {
        public StudentEducationTask(Student student, EducationTask task): this(task.Id, student, task.Material, task.Questions)
        {

        }
        public StudentEducationTask(int id, Student student, EducationMaterial educationMaterial, 
            IEnumerable<TaskQuestion> questions):this(id, student, educationMaterial, questions, null)
        {

        }
        public StudentEducationTask(int id, Student student, EducationMaterial educationMaterial,
            IEnumerable<TaskQuestion> questions, EducationTaskSolution solution): base(id, educationMaterial, questions.ToList())
        {
            Student = student;
            Solution = solution;
        }
        public Student Student { get; }
        public EducationTaskSolution Solution { get; }
        public bool IsDone => Solution != null;
    }
}
