using APanel.Commands;
using APanel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace APanel.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel
    {
        public ICommand AuthenticateCommand { get; }

        public AuthenticationViewModel()
        {
            AuthenticateCommand = new AuthenticateCommand();
        }
    }
}
