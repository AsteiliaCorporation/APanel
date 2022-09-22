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
    internal class NavigationViewModel : BaseViewModel
    {
        public ICommand NavigateConsoleCommand { get; }
        public ICommand NavigateFileManagerCommand { get; }

        private readonly Navigation navigation = new Navigation();

        public NavigationViewModel()
        {
            NavigateConsoleCommand = new Command(ExecuteNavigateConsoleCommand, CanExecuteNavigateConsoleCommand);
            NavigateFileManagerCommand = new Command(ExecuteNavigateFileManagerCommand, CanExecuteNavigateFileManagerCommand);
            navigation.CurrentViewModel = new ConsoleViewModel();

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private bool CanExecuteNavigateFileManagerCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteNavigateFileManagerCommand(object obj)
        {
            navigation.CurrentViewModel = new FileManagerViewModel();
        }

        private bool CanExecuteNavigateConsoleCommand(object obj)
        {
            if (Equals(CurrentViewModel.GetType, consoleViewModel.GetType))
            {
                return false;
            }

            return true;
        }

        private void ExecuteNavigateConsoleCommand(object obj)
        {
            navigation.CurrentViewModel = new ConsoleViewModel();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel CurrentViewModel => navigation.CurrentViewModel;

        private ConsoleViewModel consoleViewModel;
    }
}
