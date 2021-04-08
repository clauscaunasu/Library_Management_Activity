using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        private Encrypter enc = new Encrypter();
        private Client client = new Client();
        public LoginUser()
        {
            InitializeComponent();
        }
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var username = TxtUsername.Text;
            var password = TxtPassword.Password;

            if (username == "" && password == "")
            {
                MessageBox.Show("Must enter username and password");
                TxtPassword.Focus();
                TxtPassword.Focus();
            }
            else
            {
                client.Username = username;
                client.Password = password;
                if (_serviceClient.MemberLogin(client) >= 0)
                {
                    if (_serviceClient.MemberLogin(client) == 0)
                    {
                        var userHome = new UserHome();
                        userHome.Show();
                        this.Close();
                    }
                    else
                    {
                        var adminHome = new AdminHome();
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

