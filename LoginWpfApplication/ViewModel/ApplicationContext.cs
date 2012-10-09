using System.Windows.Input;
using LoginWpfApplication.Commands;

namespace LoginWpfApplication.ViewModel
{
    public class ApplicationContext
    {
        private LoginWindow loginWindow;

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
                if (loginWindow == null)
                    loginWindow = new LoginWindow { DataContext = GetLoginViewModel() };
                return loginWindow;
            }
        }

        public ICommand CloseLogin
        {
            get { return new CloseLoginCommand(this); }
        }

        public void DestroyWindow()
        {
            loginWindow = null;
        }
    }
}
