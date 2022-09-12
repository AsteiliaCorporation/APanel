using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APanel.MVVM.ViewModel
{
    internal class MainViewModel
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
        public Test testVM;

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
            testVM = new Test();
        }
    }
}
