﻿using APanel.Helpers;
using APanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Commands
{
    public class NavigateConsoleCommand : Command
    {
        private readonly Navigation navigation;

        public NavigateConsoleCommand(Navigation navigation)
        {
            this.navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            navigation.CurrentViewModel = new ConsoleViewModel();
        }
    }
}
