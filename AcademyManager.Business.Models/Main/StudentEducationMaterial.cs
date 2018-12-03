using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class StudentEducationMaterial : EducationMaterial
    {
        public StudentEducationMaterial(Student student, EducationMaterial material): this(student, material.Owner, material.Theme,
            material.Parts.Select(i => new SerializableKeyValuePair<EducationMaterialPart, bool>(i, false)))
        {

        }
        public StudentEducationMaterial(Student student, Teacher teacher, string theme,
            IEnumerable<SerializableKeyValuePair<EducationMaterialPart, bool>> partsInfo) : this(student, teacher, theme, 0, partsInfo)
        {

        }
        public StudentEducationMaterial(Student student, Teacher teacher, string theme, int sessionsCount,
            IEnumerable<SerializableKeyValuePair<EducationMaterialPart, bool>> partsInfo) : base(teacher, theme, partsInfo.Select(i => i.Key))
        {
            Student = student;
            SessionsCount = sessionsCount;
            PartsInfo = partsInfo.ToList();
        }

        public Student Student { get; }
        public int SessionsCount { get; }
        public ICollection<SerializableKeyValuePair<EducationMaterialPart, bool>> PartsInfo { get; }
        public bool IsCompleted => PartsInfo.All(i => i.Value);
    }
}
