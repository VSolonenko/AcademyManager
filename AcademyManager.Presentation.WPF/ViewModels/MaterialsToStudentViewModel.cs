using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.Models.Main;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class MaterialSelectorItem: BaseViewModel
    {
    

        public MaterialSelectorItem(EducationMaterial educationMaterial, bool isSelected)
        {
            EducationMaterial = educationMaterial;
        }
       
        public bool IsSelected { get; set; }

        public EducationMaterial EducationMaterial { get; }
    }

    class MaterialsToStudentViewModel: BaseViewModel
    {
        public MaterialsToStudentViewModel(IEnumerable<MaterialSelectorItem> materials)
        {
            Materials = new ObservableCollection<MaterialSelectorItem>(materials);
            Apply = new DelegateCommand(() => {
                ItemsChanged?.Invoke(this, EventArgs.Empty);
                ViewService.Message("Материалы прикрепленны");
            });
        }
        public ObservableCollection<MaterialSelectorItem> Materials { get; }
        public ICommand Apply { get; }
        public EventHandler ItemsChanged;
    }
}
