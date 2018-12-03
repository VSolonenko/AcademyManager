using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class EducationTask
    {
        public EducationTask(int id, EducationMaterial material, ICollection<TaskQuestion> questions)
        {
            Material = material;
            Questions = questions;
            Id = id;
        }
        public int Id { get; }
        public EducationMaterial Material { get; }
        public ICollection<TaskQuestion> Questions { get; }

    }
}
