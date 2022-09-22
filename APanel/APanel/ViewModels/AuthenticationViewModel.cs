using APanel.Commands;
using APanel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace APanel.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }
        public ICommand CreateAccountCommand { get; }

        private string _username;
        private string _password;

        public AuthenticationViewModel()
        {
            LoginCommand = new Command(obj => ExecuteLoginCommand("", ""), CanExecuteLoginCommand);
            CreateAccountCommand = new Command(ExecuteCreateAccountCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return true;
        }

        private async void ExecuteLoginCommand(string username, string password)
        {
            Application.Current.MainWindow.Close();

            Application.Current.MainWindow = new MainView();

            await Task.Delay(500);

            Application.Current.MainWindow.Show();
        }

        private async void ExecuteCreateAccountCommand(object obj)
        {
            Application.Current.MainWindow.Close();

            Application.Current.MainWindow = new RegistrationView();

            await Task.Delay(500);

            Application.Current.MainWindow.Show();
        }

        public string Username
        {
            get { return _username; }

            set
            {
                _username = value;

                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged();
            }
        }
    }
}
