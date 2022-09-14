﻿using APanel.Helpers;
using APanel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.Commands
{
    public class AuthenticateCommand : Command
    {
        private readonly Navigation navigation;

        public AuthenticateCommand(Navigation navigation)
        {
            this.navigation = navigation;
        }

        public override void Execute(object? parameter)
        {
            navigation.CurrentViewModel = new NavigationViewModel(navigation);
        }
    }
}
