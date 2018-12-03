using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class EducationSubject
    {
        public EducationSubject(string name, ICollection<EducationMaterial> materials)
        {

        }
        public EducationSubject(string name): this( name, new List<EducationMaterial>())
        {

        }
        public string Name { get; }
        ICollection<EducationMaterial> Materials { get; }
    }
}
