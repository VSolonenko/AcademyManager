

using System;
using System.Collections.Generic;
using System.Linq;
using AcademyManager.Business.Models.Users;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class EducationMaterial
    {
        public EducationMaterial(Teacher teacher, string theme, IEnumerable<EducationMaterialPart> parts)
        {
            Owner = teacher;
            Theme = theme;
            Parts = parts.ToList();
        }

        public string Theme { get; }
        public ICollection<EducationMaterialPart> Parts { get; }
        public Teacher Owner { get; }
        public override string ToString() => Theme;
        public override bool Equals(object obj)
        {
            var isEqual = false;

            if (obj is EducationMaterial) {
                var foo = (EducationMaterial)obj;
                if (base.Equals(obj)) {
                    isEqual = base.Equals(obj);
                }
                else if (foo.Owner.Equals(Owner) && foo.Owner.Equals(Owner)) {
                    isEqual = true;
                }
            }
            return isEqual;
        }
    }
}
