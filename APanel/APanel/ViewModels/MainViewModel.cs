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
    public class MainViewModel : BaseViewModel
    {
        private readonly Navigation navigation;

        public MainViewModel(Navigation navigation)
        {
            this.navigation = navigation;
            navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseViewModel? CurrentViewModel => navigation.CurrentViewModel;
    }
}
