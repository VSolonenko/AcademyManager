using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class MaterialPartViewModel: BaseViewModel
    {
        public string Theme { get; set; }
        public string Content { get; set; }
        public bool IsReaded { get; set; }
    }
}
