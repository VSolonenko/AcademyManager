using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Data.LocalFileData
{
    class MaterialsProvider : BaseProvider<EducationMaterial>, IEducationMaterailsProvider
    {
        public MaterialsProvider(string dirPath) : base(dirPath, "materails.bin")
        {

        }

        protected override bool Compare(EducationMaterial first, EducationMaterial second)
        {
            if (first.Owner == second.Owner && first.Theme == second.Theme) {
                return true;
            }
            return false;
        }
    }
}
