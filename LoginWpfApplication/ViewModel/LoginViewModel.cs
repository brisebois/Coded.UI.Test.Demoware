using System.ComponentModel;
using LoginWpfApplication.Commands;

namespace LoginWpfApplication.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApplicationContext applicationContext;
        private string password;
        private string errorMessage;

        public LoginViewModel(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public string UserName
        {
            get { return applicationContext.UserName; }
            set
            {
                applicationContext.UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginCommand LoginCommand
        {
            get
            {
                return new LoginCommand(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetAuthenticated()
        {
            applicationContext.IsAuthenticated = true;
            ErrorMessage = string.Empty;
            applicationContext.CloseLogin.Execute(null);
        }

        public void SetUnknownCredentials()
        {
            applicationContext.IsAuthenticated = false;
            ErrorMessage = "The username and password combination was invalid";
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public void SetNoCredentialsWereProdided()
        {
            applicationContext.IsAuthenticated = false;
            ErrorMessage = "The username and password are required";
        }
    }
}