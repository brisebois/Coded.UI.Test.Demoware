using System;
using System.Windows.Input;
using LoginWpfApplication.ViewModel;

namespace LoginWpfApplication.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;

            loginViewModel.PropertyChanged += LoginViewModelPropertyChanged;
        }

        void LoginViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged.Invoke(sender, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if((string.IsNullOrEmpty(loginViewModel.Password) && string.IsNullOrEmpty(loginViewModel.UserName)))
            loginViewModel.SetNoCredentialsWereProdided();
            else
            if (loginViewModel.Password == "P@ssword" && loginViewModel.UserName == "alexandre")
                loginViewModel.SetAuthenticated();
            else
            {
                loginViewModel.SetUnknownCredentials();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}