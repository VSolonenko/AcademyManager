using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AcademyManager.Presentation.WPF.Common.MVVM.ViewService
{
    class ViewService : IViewService
    {

        public IView CreateView(BaseViewModel viewModel, BaseViewModel ownerViewModel)
        {

            //Assembly assembly = Assembly.GetCallingAssembly();
            Assembly assembly = viewModel.GetType().Assembly;
            foreach (Type type in assembly.GetTypes())
            {
                ViewForAttribute attribute = type.GetCustomAttribute<ViewForAttribute>();
                if (attribute != null)
                {
                    if (attribute.ViewModelType.IsAssignableFrom(viewModel.GetType()))
                    {
                      
                        if (ownerViewModel != null)
                        {
                            foreach (Window openedWindow in Application.Current.Windows)
                            {
                                if (openedWindow.DataContext == ownerViewModel)
                                {
                                    return (WindowView)openedWindow;
                                }
                            }
                        }
                        var window = (WindowView)Activator.CreateInstance(type);
                        window.DataContext = viewModel;
                        return window;
                    }
                }
            }
            throw new InvalidOperationException($"Cannot create view for view model of type '{viewModel.GetType()}'.");
        }

        public IView CreateView(BaseViewModel viewModel) => CreateView(viewModel, null);
        public bool GetIfOpened(out IView view, object viewModel)
        {
            view = null;
            foreach (Window openedWindow in Application.Current.Windows)
            {
                if (openedWindow.DataContext == viewModel)
                {
                    view = (WindowView)openedWindow;
                }
            }
            return view != null;
        }
        public IPasswordHandler GetPasswordHandler(IView view) => view.GetType().GetInterface(nameof(IPasswordHandler)) == typeof(IPasswordHandler) ? ((IPasswordHandler)view) : null;
        public void Message(string message) => MessageBox.Show(message);
        public void MessageError(string message, string caption) => MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
