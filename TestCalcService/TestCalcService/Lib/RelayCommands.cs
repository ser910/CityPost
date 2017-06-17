using System;
using System.Windows.Input;
 
namespace TestCalcService
{
    class RelayCommand:  ICommand
    {
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action<object> action)
        {
            ExecuteDelegate = action;
        }
        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
            {
                CommandManager.InvalidateRequerySuggested();
                return CanExecuteDelegate(parameter);
            }
            return true;
        }
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
            {
                ExecuteDelegate(parameter);
            }
        }
    }
}