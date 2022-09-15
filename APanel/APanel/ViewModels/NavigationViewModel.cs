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
            NavigateConsoleCommand = new NavigateConsoleCommand(navigation);
            NavigateFileManagerCommand = new NavigateFileManagerCommand(navigation);
            navigation.CurrentViewModel = new ConsoleViewModel();

            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel? CurrentViewModel => navigation.CurrentViewModel;
    }
}
