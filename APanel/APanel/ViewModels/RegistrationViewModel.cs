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
    internal class RegistrationViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; }
        public ICommand SignInCommand { get; }

        private string _username;
        private string _email;
        private string _password;
        private string _passwordRepeat;

        public RegistrationViewModel()
        {
            RegisterCommand = new Command(ExecuteRegisterCommand, CanExecuteRegisterCommand);
            SignInCommand = new Command(ExecuteSignInCommand);
        }

        private bool CanExecuteRegisterCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRegisterCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private async void ExecuteSignInCommand(object obj)
        {
            Application.Current.MainWindow.Close();

            Application.Current.MainWindow = new AuthenticationView();

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
