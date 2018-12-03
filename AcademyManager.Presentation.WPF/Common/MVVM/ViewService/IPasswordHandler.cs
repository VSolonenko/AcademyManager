﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyManager.Presentation.WPF.Common.MVVM.ViewService
{
    interface IPasswordHandler
    {
        string GetPassword();
        event EventHandler PasswordUpdated;
    }
}
