using System.Collections.Generic;
using System.Linq;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Data;

namespace AcademyManager.Business.EducationMaterialsManager
{
    internal class EducationTasksManager : IEducationTasksManager
    {
        private readonly IEducationTasksProvider _tasksProvider;
        private readonly IStudentEducationTaskProvider _educationTaskProvider;

        public EducationTasksManager(IEducationTasksProvider tasksProvider, IStudentEducationTaskProvider educationTaskProvider)
        {
            _tasksProvider = tasksProvider;
            _educationTaskProvider = educationTaskProvider;
        }

        public int Id(Teacher teacher) => Select(teacher).Any() ? Select(teacher).Last().Id + 1 : 1;
        public void Insert(EducationTask task) => _tasksProvider.Create(task);
        public void Insert(StudentEducationTask educationTask)
        {
            var finded = _educationTaskProvider.Select().FirstOrDefault(i => i.Student.Equals(educationTask.Student) && i.Material.Equals(educationTask.Material) && i.Id == educationTask.Id);
            if(finded != null) {
                _educationTaskProvider.Update(educationTask);
            }
            else {
                _educationTaskProvider.Create(educationTask);
            }
        }
        public IEnumerable<EducationTask> Select(Teacher teacher) => _tasksProvider.Select().Where(i => i.Material.Owner.Equals(teacher));
        public IEnumerable<StudentEducationTask> Select(Student student) => _educationTaskProvider.Select().Where(i => i.Student.Equals(student));
        public IEnumerable<StudentEducationTask> Select(Student student, Teacher teacher) => Select(student).Where(i => i.Material.Owner.Equals(teacher));
    }
}