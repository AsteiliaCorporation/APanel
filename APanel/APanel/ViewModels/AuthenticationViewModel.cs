using APanel.Commands;
using APanel.Databases;
using APanel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace APanel.ViewModels
{
    public class AuthenticationViewModel : BaseViewModel
    {
        private readonly IUserDatabase userDatabase;
        private ICommand _loginCommand;
        private ICommand _createAccountCommand;

        private Visibility _usernameErrorVisibility;
        private Visibility _passwordErrorVisibility;

        private string _username;
        private string _password;
        private string _usernameError;
        private string _passwordError = "Password can't be whitespace or empty!";

        public AuthenticationViewModel()
        {
            userDatabase = new UserDatabase();
            LoginCommand = new Command(ExecuteLoginCommand, CanExecuteLoginCommand);
            CreateAccountCommand = new Command(ExecuteCreateAccountCommand);
        }

        private async void ExecuteLoginCommand(object obj)
        {
            if (userDatabase.AuthenticateUser(new NetworkCredential(Username, Password)))
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), new string[] { "User" });

                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = new MainView();

                await Task.Delay(500);

                Application.Current.MainWindow.Show();
            }
            else
            {
                Password = string.Empty;
                UsernameError = "Invalid credentials!";
                UsernameErrorVisibility = Visibility.Visible;
            }
        }

        private async void ExecuteCreateAccountCommand(object obj)
        {
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = new RegistrationView();

            await Task.Delay(500);

            Application.Current.MainWindow.Show();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                UsernameError = "Username can't be whitespace or empty!";
                UsernameErrorVisibility = Visibility.Visible;

                return false;
            }

            if (Username.Length < 2 || Username.Length > 32)
            {
                UsernameError = "Username length must be between [2-32]!";
                UsernameErrorVisibility = Visibility.Visible;

                return false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                PasswordError = "Password can't be whitespace or empty!";
                PasswordErrorVisibility = Visibility.Visible;

                return false;
            }

            if (Password.Length < 6 || Password.Length > 64)
            {
                PasswordError = "Password length must be between [6-64]!";
                PasswordErrorVisibility = Visibility.Visible;

                return false;
            }

            if (!Password.Any(x => char.IsUpper(x)))
            {
                PasswordError = "Password must contain an uppercase character!";
                PasswordErrorVisibility = Visibility.Visible;

                return false;
            }

            UsernameError = string.Empty;
            PasswordError = string.Empty;
            UsernameErrorVisibility = Visibility.Collapsed;
            PasswordErrorVisibility = Visibility.Collapsed;

            return true;
        }

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            private set
            {
                _loginCommand = value;
            }
        }

        public ICommand CreateAccountCommand
        {
            get { return _createAccountCommand; }
            private set
            {
                _createAccountCommand = value;
            }
        }

        public Visibility UsernameErrorVisibility
        {
            get { return _usernameErrorVisibility; }
            set
            {
                _usernameErrorVisibility = value;

                OnPropertyChanged();
            }
        }

        public Visibility PasswordErrorVisibility
        {
            get { return _passwordErrorVisibility; }
            set
            {
                _passwordErrorVisibility = value;

                OnPropertyChanged();
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

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;

                OnPropertyChanged();
            }
        }

        public string UsernameError 
        {
            get { return _usernameError; }
            set
            {
                _usernameError = value;

                OnPropertyChanged();
            }
        }

        public string PasswordError
        {
            get { return _passwordError; }
            set
            {
                _passwordError = value;

                OnPropertyChanged();
            }
        }
    }
}
