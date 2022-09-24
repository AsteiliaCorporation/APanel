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
        private ICommand _navigateConsoleCommand;
        private ICommand _navigateFileManagerCommand;

        private readonly Navigation navigation = new Navigation();

        public NavigationViewModel()
        {
            NavigateConsoleCommand = new Command(ExecuteNavigateConsoleCommand, CanExecuteNavigateConsoleCommand);
            NavigateFileManagerCommand = new Command(ExecuteNavigateFileManagerCommand, CanExecuteNavigateFileManagerCommand);
            navigation.CurrentViewModel = new ConsoleViewModel();

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void ExecuteNavigateFileManagerCommand(object obj)
        {
            navigation.CurrentViewModel = new FileManagerViewModel();
        }

        private void ExecuteNavigateConsoleCommand(object obj)
        {
            navigation.CurrentViewModel = new ConsoleViewModel();
        }

        private bool CanExecuteNavigateFileManagerCommand(object obj)
        {
            return true;
        }

        private bool CanExecuteNavigateConsoleCommand(object obj)
        {
            return true;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ICommand NavigateConsoleCommand
        {
            get => _navigateConsoleCommand;
            private set => _navigateConsoleCommand = value;
        }

        public ICommand NavigateFileManagerCommand
        {
            get => _navigateFileManagerCommand;
            private set => _navigateFileManagerCommand = value;
        }

        public BaseViewModel CurrentViewModel
        {
            get => navigation.CurrentViewModel;
        }
    }
}
