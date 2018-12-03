using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Data;

namespace AcademyManager.Business.EducationMaterialsManager
{
    class MaterialsManager : IEducationMaterialsManager
    {
        private readonly IEducationMaterailsProvider _materailsProvider;
        private readonly IStudentEducationMaterailsProvider _studentEducationMaterailsProvider;

        public MaterialsManager(IEducationMaterailsProvider materailsProvider, IStudentEducationMaterailsProvider studentEducationMaterailsProvider)
        {
            _materailsProvider = materailsProvider;
            _studentEducationMaterailsProvider = studentEducationMaterailsProvider;
        }
        public void Insert(EducationMaterial educationMaterial) => _materailsProvider.Create(educationMaterial);
        public void Insert(StudentEducationMaterial educationMaterial)
        {
            var materials = _studentEducationMaterailsProvider.Select();
            if(materials.Any(i => i.Theme == educationMaterial.Theme && i.Student.Equals(educationMaterial.Student))) {
                _studentEducationMaterailsProvider.Update(educationMaterial);
            }
            else {
                _studentEducationMaterailsProvider.Create(educationMaterial);
            }
        }
        public IEnumerable<EducationMaterial> Select(Teacher teacher) => _materailsProvider.Select().Where(i => i.Owner.Equals(teacher));
        public IEnumerable<StudentEducationMaterial> Select(Student student) => _studentEducationMaterailsProvider.Select().Where(i => i.Student.Equals(student));
        public IEnumerable<StudentEducationMaterial> Select(Student student, Teacher teacher) => Select(student).Where(i => i.Owner.Equals(teacher));
    }
}
