using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models;
using AcademyManager.Business.Models.Main;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{

    class MaterialDetailsWindowViewModel : BaseViewModel
    {
        private MaterialPartViewModel _selectedPart;
        private int _sessionCount;

        public MaterialDetailsWindowViewModel(StudentEducationMaterial educationMaterial, IEducationMaterialsManager materialsManager)
        {
            Theme = educationMaterial.Theme;
            Parts = new ObservableCollection<MaterialPartViewModel>(educationMaterial.PartsInfo.Select(i => new MaterialPartViewModel { Theme = i.Key.Theme, Content = i.Key.Content, IsReaded = i.Value }));
            _sessionCount = educationMaterial.SessionsCount + 1;
            Close = new DelegateCommand(() => {
                var parts = new List<SerializableKeyValuePair<EducationMaterialPart, bool>>();
                foreach (var part in Parts) {
                    var origin = educationMaterial.Parts.FirstOrDefault(i => i.Theme == part.Theme);
                    parts.Add(new SerializableKeyValuePair<EducationMaterialPart, bool>(origin, part.IsReaded));
                }
                var result = new StudentEducationMaterial(educationMaterial.Student, educationMaterial.Owner, educationMaterial.Theme, _sessionCount, parts);
                materialsManager.Insert(result);
                if (ViewService.GetIfOpened(out var view, this)) {
                    view.Close();
                }
            });
        }
        public string Theme { get; }
        public MaterialPartViewModel SelectedPart {
            get => _selectedPart; set {
                if(_selectedPart != null) {
                    _selectedPart.IsReaded = true;
                }
                SetProperty(ref _selectedPart, value);
            }
        }
        public IEnumerable<MaterialPartViewModel> Parts { get; }
        public ICommand Close { get; }
    }
}
