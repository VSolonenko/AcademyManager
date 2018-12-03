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
    class TaskSelectorItem : BaseViewModel
    {
        private bool _isSelected;

        public TaskSelectorItem(EducationTask task, bool isSelected)
        {
            Task = task;
            IsSelected = isSelected;
        }
        public EducationTask Task { get; }
        public bool IsSelected { get => _isSelected; set => SetProperty(ref _isSelected, value); }
    }
    class TaskToStudentWindowViewModel : BaseViewModel
    {
       
        public TaskToStudentWindowViewModel(IEnumerable<TaskSelectorItem> tasks)
        {
            Tasks = new ObservableCollection<TaskSelectorItem>(tasks);
            Apply = new DelegateCommand(() => {
             
                ItemsChanged?.Invoke(this, EventArgs.Empty);
                ViewService.Message("Контрольные работы закрепленны");
            });
        }

        public ObservableCollection<TaskSelectorItem> Tasks { get; }
        public ICommand Apply { get; }
        public event EventHandler ItemsChanged;

    }
}
