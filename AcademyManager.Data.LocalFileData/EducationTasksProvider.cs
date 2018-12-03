using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Business.Models.Main;

namespace AcademyManager.Data.LocalFileData
{
    class EducationTasksProvider : BaseProvider<EducationTask>, IEducationTasksProvider
    {
        public EducationTasksProvider(string path) : base(path, "tasks.bin")
        {
        }

        protected override bool Compare(EducationTask first, EducationTask second)
        {
            if (first.Id == second.Id) {
                return true;
            }
            return false;
        }

    }
}
