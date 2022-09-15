using APanel.ViewModels;
using APanel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APanel.Commands
{
    public class AuthenticateCommand : Command
    {
        public override async void Execute(object? parameter)
        {
            Window mainView = new MainView()
            {
                DataContext = new MainViewModel()
            };

            Application.Current.MainWindow.Close();

            await Task.Delay(500);

            mainView.Show();
        }
    }
}
