using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace APanel.MVVM.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public PrimaryViewModel primaryVM;
        public ConsoleViewModel consoleVM;
        public FileManagerViewModel fileManagerVM;
        public DatabasesViewModel databasesVM;
        public SchedulesViewModel schedulesVM;
        public UsersViewModel usersVM;
        public BackupsViewModel backupsVM;
        public NetworkViewModel networkVM;
        public StartupViewModel startupVM;
        public SettingsViewModel settingsVM;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            primaryVM = new PrimaryViewModel();
            consoleVM = new ConsoleViewModel();
            fileManagerVM = new FileManagerViewModel();
            databasesVM = new DatabasesViewModel();
            schedulesVM = new SchedulesViewModel();
            usersVM = new UsersViewModel();
            backupsVM = new BackupsViewModel();
            networkVM = new NetworkViewModel();
            startupVM = new StartupViewModel();
            settingsVM = new SettingsViewModel();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
