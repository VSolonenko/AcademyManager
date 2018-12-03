using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Business.EducationMaterialsManager
{
    class EducationTaskExamination : IEducationTaskExaminationManager
    {
        public StudentEducationTask Examine(StudentEducationTask task, IEnumerable<KeyValuePair<TaskQuestion, string>> answers)
        {
            var list = new List<KeyValuePair<TaskQuestion, bool>>();
            foreach (var question in task.Questions) {
                var answer = answers.FirstOrDefault(i => i.Key.Equals(question));
                if (answer.Key != null && question.IsCorrect(answer.Value)) {
                    list.Add(new KeyValuePair<TaskQuestion, bool>(answer.Key, true));
                }
                else {
                    list.Add(new KeyValuePair<TaskQuestion, bool>(answer.Key, false));
                }
            }
            double mark = 5.0 / list.Count * list.Where(i => i.Value == true).Count();
            return new StudentEducationTask(task.Id, task.Student, task.Material, task.Questions,
                                            new EducationTaskSolution(task, list, (int)Math.Ceiling(mark != 0 ? mark : 1)));
        }
    }
}
