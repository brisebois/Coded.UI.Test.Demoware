using System.Windows.Input;

namespace LoginWpfApplication.ViewModel
{
    public class ApplicationContext
    {
        public ApplicationContext()
        {
            
        }

        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }

        public LoginViewModel GetLoginViewModel()
        {
            return new LoginViewModel(this);
        }

        public ICommand ShowLogin
        {
            get
            {
                return new ShowLoginCommand(this);
            }
        }

        public LoginWindow LoginWindow
        {
            get
            {
                return new LoginWindow { DataContext = GetLoginViewModel() };
            }
        }

        public ICommand CloseLogin
        {
            get { return new CloseLoginCommand(this); }
        }
    }
}
