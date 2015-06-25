using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace flc.FrontDoor.Common
{
    
        public class ActionCommand<T> : ICommand where T : class
        {
            readonly Action<T> _execute;
            readonly Predicate<T> _canExecute;

            public ActionCommand(Action<T> execute)
                : this(execute, null)
            {
            }

            public ActionCommand(Action<T> execute, Predicate<T> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute cannot be null");

                _execute = execute;
                _canExecute = canExecute;
            }

            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }

            public event EventHandler CanExecuteChanged;

            public void RaiseCanExecuteChanged()
            {
                var handler = CanExecuteChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }

            public void Execute(object parameter)
            {
                var param = parameter as T;

                if (parameter != null && param == null)
                    throw new InvalidOperationException("Wrong type of parameter being passed in.  Expected [" + typeof(T) + "]but was [" + parameter.GetType() + "]");

                if (!CanExecute(param))
                    throw new InvalidOperationException("Should not try to execute command that cannot be executed");

                _execute(param);
            }
        }

        public class ActionCommand : ActionCommand<object>
        {
            public ActionCommand(Action execute)
                : base(arg => execute())
            { }

            public ActionCommand(Action execute, Func<bool> canExecute)
                : base(arg => execute(), arg => canExecute())
            { }
        }

        public class RelayCommand : ICommand
        {
            #region Fields

            readonly Action<object> _execute;
            readonly Predicate<object> _canExecute;

            #endregion // Fields

            #region Constructors

            public RelayCommand(Action<object> execute)
                : this(execute, null)
            {
            }

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }
            #endregion // Constructors

            #region ICommand Members

            [DebuggerStepThrough]
            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute(parameter);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }

            #endregion // ICommand Members
        }


}

