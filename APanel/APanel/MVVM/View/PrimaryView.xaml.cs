using APanel.MVVM.ViewModel;
using System.Windows.Controls;

namespace APanel.MVVM.View
{
    /// <summary>
    /// Interaction logic for PrimaryView.xaml
    /// </summary>
    public partial class PrimaryView : UserControl
    {
        private readonly MainViewModel mainVM;

        public PrimaryView()
        {
            InitializeComponent();

            mainVM = new MainViewModel();
            //contentControl.Content = mainVM.consoleVM;
            contentControl.Content = mainVM.testVM;
        }

        private void btnConsole_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.consoleVM;
        }

        private void btnFileManager_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.fileManagerVM;
        }

        private void btnDatabases_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.databasesVM;
        }

        private void btnSchedules_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.schedulesVM;
        }

        private void btnUsers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.usersVM;
        }

        private void btnBackups_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.backupsVM;
        }

        private void btnNetwork_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.networkVM;
        }

        private void btnStartup_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.startupVM;
        }

        private void btnSettings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            contentControl.Content = mainVM.settingsVM;
        }
    }
}
