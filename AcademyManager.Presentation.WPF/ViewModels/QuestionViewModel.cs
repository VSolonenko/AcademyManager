using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class QuestionViewModel: BaseViewModel
    {
        public string Question { get; set; }
        public string Correct { get; set; }
        public string UnCorrect { get; set; }
       
    }
}
