using System;
using System.Windows.Input;

namespace BattleBuddy.Base
{
    public class Command : ViewModel, ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecuteAction;

        public Command(Action action, Func<bool>? canExecuteAction = null)
        {
            _action = action;

            if(_canExecuteAction == null || canExecuteAction == null)
            {
                _canExecuteAction = () => true;
            }
            else
            {
                _canExecuteAction = canExecuteAction;
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecuteAction.Invoke();

        public void Execute(object? parameter) => _action.Invoke();
    }
}
