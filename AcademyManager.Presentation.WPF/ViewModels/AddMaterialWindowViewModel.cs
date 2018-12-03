using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AcademyManager.Business.EducationMaterialsManager;
using AcademyManager.Business.Models.Main;
using AcademyManager.Business.Models.Users;
using AcademyManager.Presentation.WPF.Common.MVVM;

namespace AcademyManager.Presentation.WPF.ViewModels
{
    class AddMaterialWindowViewModel: BaseViewModel
    {
        private readonly IEducationMaterialsManager _materialsManager;
        private readonly Teacher _teacher;

        public AddMaterialWindowViewModel(IEducationMaterialsManager materialsManager, Teacher teacher)
        {
            _materialsManager = materialsManager;
            _teacher = teacher;
            MaterialParts = new ObservableCollection<MaterialPartViewModel>();
            Save = new DelegateCommand(() => {
                _materialsManager.Insert(new EducationMaterial(_teacher, Theme, MaterialParts.Select(i => new EducationMaterialPart(i.Theme, i.Content)).ToList()));
                ViewService.Message("Материал сохранен");
            });
            AddPart = new DelegateCommand(() => MaterialParts.Add(new MaterialPartViewModel()));
        }
        public string Theme { get; set; }
        public ObservableCollection<MaterialPartViewModel> MaterialParts { get; }
        public ICommand Save { get; }
        public ICommand AddPart { get; }
    }
}
