using System.Windows.Input;
using APanel.Helper;

namespace APanel.MVVM.ViewModel
{
    internal class ConsoleViewModel
    {
        public ICommand StartServerCommand;
        public ICommand RestartServerCommand;
        public ICommand StopServerCommand;

        public ConsoleViewModel()
        {
            StartServerCommand = new Command(ExecuteStartServerCommand);
            RestartServerCommand = new Command(ExecuteRestartServerCommand);
            StopServerCommand = new Command(ExecuteStopServerCommand);
        }

        public void ExecuteStartServerCommand()
        {

        }

        public void ExecuteRestartServerCommand()
        {
            
        }

        public void ExecuteStopServerCommand()
        {

        }
    }
}
