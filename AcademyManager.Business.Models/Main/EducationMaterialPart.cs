using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Business.Models.Main
{
    [Serializable]
    public class EducationMaterialPart
    {
        public EducationMaterialPart(string theme, string content)
        {
            Theme = theme;
            Content = content;
        }
        public string Theme { get; }
        public string Content { get; }
    }
}
