using System;
using System.Windows.Input;

namespace LoginWpfApplication.ViewModel
{
    public class ShowLoginCommand : ICommand
    {
        private readonly ApplicationContext applicationContext;

        public ShowLoginCommand(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            applicationContext.LoginWindow.Show();
        }

        public event EventHandler CanExecuteChanged;
    }
}