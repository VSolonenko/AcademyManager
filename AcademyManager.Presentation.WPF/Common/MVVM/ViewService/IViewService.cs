using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Presentation.WPF.Common.MVVM.ViewService
{
    interface IViewService
    {
        IView CreateView(BaseViewModel viewModel);
        bool GetIfOpened(out IView view, object viewModel);
        void Message(string message);
        void MessageError(string message, string caption);
        IPasswordHandler GetPasswordHandler(IView view);

    }
}
