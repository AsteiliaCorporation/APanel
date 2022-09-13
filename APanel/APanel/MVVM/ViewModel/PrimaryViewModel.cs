﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.MVVM.ViewModel
{
    internal class PrimaryViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public PrimaryViewModel()
        {
            CurrentViewModel = new ConsoleViewModel();
        }
    }
}
