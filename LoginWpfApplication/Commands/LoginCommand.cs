using System;
using System.Collections.Generic;
using System.Linq;
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
            var names = new List<string> {"Alexandre", "Etienne","DotNetMontreal"};
            if ((string.IsNullOrEmpty(loginViewModel.Password) && string.IsNullOrEmpty(loginViewModel.UserName)))
                loginViewModel.SetNoCredentialsWereProdided();
            else
                if (loginViewModel.Password == "P@ssword" && names.Any(n => loginViewModel.UserName.ToUpper() == n.ToUpper()))
                    loginViewModel.SetAuthenticated();
                else
                {
                    loginViewModel.SetUnknownCredentials();
                }
        }

        public event EventHandler CanExecuteChanged;
    }
}