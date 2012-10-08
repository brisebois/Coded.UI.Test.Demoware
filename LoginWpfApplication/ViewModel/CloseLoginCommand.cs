using System;
using System.Windows.Input;

namespace LoginWpfApplication.ViewModel
{
    public class CloseLoginCommand : ICommand
    {
        private readonly ApplicationContext applicationContext;

        public CloseLoginCommand(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            applicationContext.LoginWindow.Close();
        }

        public event EventHandler CanExecuteChanged;
    }
}