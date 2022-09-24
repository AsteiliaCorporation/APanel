using APanel.Authentication;
using APanel.Commands;
using APanel.Databases;
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
    internal class RegistrationViewModel : BaseViewModel
    {
        private IUserDatabase userDatabase;
        private ICommand _registerCommand;
        private ICommand _signInCommand;

        private string _username;
        private string _email;
        private string _password;
        private string _passwordRepeat;

        public RegistrationViewModel()
        {
            userDatabase = new UserDatabase();
            RegisterCommand = new Command(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            SignInCommand = new Command(ExecuteSignInCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            userDatabase.Add(new User(Username, Password, Email));
        }

        private async void ExecuteSignInCommand(object obj)
        {
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = new AuthenticationView();

            await Task.Delay(500);

            Application.Current.MainWindow.Show();
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(PasswordRepeat))
            {
                return false;
            }

            return true;
        }

        public ICommand RegisterCommand
        {
            get { return _registerCommand; }
            private set
            {
                _registerCommand = value; 
            }
        }

        public ICommand SignInCommand
        {
            get { return _signInCommand; }
            private set
            {
                _signInCommand = value;
            }
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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;

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

        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set
            {
                _passwordRepeat = value;

                OnPropertyChanged();
            }
        }
    }
}
