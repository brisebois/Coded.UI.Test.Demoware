using System;
using System.Windows.Input;
using LoginWpfApplication.ViewModel;

namespace LoginWpfApplication.Commands
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
            applicationContext.DestroyWindow();
        }

        public event EventHandler CanExecuteChanged;
    }
}