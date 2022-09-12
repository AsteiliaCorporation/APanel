using System;
using System.Windows.Input;

namespace APanel.Helper
{
    public class Command : ICommand
    {
        private bool _isEnabled = true;

        public string? DisplayName { get; set; }

        public Action Action { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;

                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Command(Action action)
        {
            Action = action;
        }

        public void Execute(object? parameter)
        {
            Action?.Invoke();
        }

        public bool CanExecute(object? parameter)
        {
            return IsEnabled;
        }   
    }

    public class Command<T> : ICommand
    {
        private bool _isEnabled = true;

        public Action<T> Action { get; set; }

        public void Execute(object? parameter)
        {
            if (Action != null && parameter is T)
                Action((T)parameter);
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;

                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Command(Action<T> action)
        {
            Action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return IsEnabled;
        }

        public event EventHandler? CanExecuteChanged;   
    }
}
