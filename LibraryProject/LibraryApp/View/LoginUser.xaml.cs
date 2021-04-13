using System.Windows;
using System.Windows.Input;
using LibraryApp.BusinessLogic;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly Encrypter _enc = new Encrypter();
        private readonly Client _client = new Client();
        public LoginUser()
        {
            InitializeComponent();
        }
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var username = TxtUsername.Text;
            var password = _enc.Encrypt(TxtPassword.Password);

            if (username == "" && password == "")
            {
                MessageBox.Show("Must enter username and password");
                TxtPassword.Focus();
                TxtPassword.Focus();
            }
            else
            {
                _client.Username = username;
                _client.Password = password;
                if (_serviceClient.MemberLogin(_client) >= 0)
                {
                    if (_serviceClient.MemberLogin(_client) == 0)
                    {
                        var userHome = new UserHome(_client);
                        userHome.Show();
                        this.Close();
                    }
                    else
                    {
                        var adminHome = new AdminHome(_client);
                        adminHome.Show();
                        this.Close();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Username or password incorrect");
                }
            }


        }


        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

