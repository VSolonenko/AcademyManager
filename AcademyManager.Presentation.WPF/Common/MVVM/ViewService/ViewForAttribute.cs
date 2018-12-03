using System;


namespace AcademyManager.Presentation.WPF.Common.MVVM.ViewService
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ViewForAttribute : Attribute
    {
        public ViewForAttribute(Type viewModelType)
        {
            ViewModelType = viewModelType;
        }
        public Type ViewModelType { get; }
    }
}
