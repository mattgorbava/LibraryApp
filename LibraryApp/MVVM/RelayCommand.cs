//using System.Windows.Input;

//namespace LibraryApp.MVVM
//{
//    public class RelayCommand : ICommand
//    {
//        private Action<object> execute;
//        private Func<object, bool> canExecute;

//        public event EventHandler? CanExecuteChanged
//        {
//            add { CommandManager.RequerySuggested += value; }
//            remove {  CommandManager.RequerySuggested -= value; }
//        }

//        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
//        {
//            this.execute = execute;
//            this.canExecute = canExecute;
//        }

//        public bool CanExecute(object? parameter)
//        {
//            return canExecute == null || canExecute(parameter);
//        }

//        public void Execute(object? parameter)
//        {
//            execute(parameter);
//        }
//    }
//}


using System.Windows.Input;

namespace LibraryApp.MVVM;

public class RelayCommand<T>(Action<T> workToDo, Predicate<T> canExecute) : ICommand
{
    private readonly Action<T> _commandTask = workToDo;

    public RelayCommand(Action<T> workToDo)
        : this(workToDo, DefaultCanExecute)
    {
        _commandTask = workToDo;
    }

    private static bool DefaultCanExecute(T parameter)
    {
        return true;
    }

    public bool CanExecute(object parameter)
    {
        return canExecute != null && canExecute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object parameter)
    {
        _commandTask((T)parameter);
    }
}