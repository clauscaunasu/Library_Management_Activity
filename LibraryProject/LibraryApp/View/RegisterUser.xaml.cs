using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryApp.BusinessLogic;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        private Encrypter enc = new Encrypter();
        private  Client client = new Client();
         

        public RegisterUser()
        {
            InitializeComponent();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            /*var result = _serviceClient.Register(TxtFirstname.Text, TxtLastname.Text, TxtAddress.Text, TxtPhone.Text,
                TxtUsername.Text, enc.Encrypt(TxtPassword.Password));
            MessageBox.Show(result ? "success" : "failed");*/

            client.FirstName = TxtFirstname.Text;
            client.LastName = TxtLastname.Text;
            client.Address = TxtAddress.Text;
            client.Telephone = TxtPhone.Text;
            client.Username = TxtUsername.Text;
            client.Password = enc.Encrypt(TxtPassword.Password);

            if (Regex.IsMatch(client.Address,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase))
            {
                MessageBox.Show("password is wrong");
            }

            if (!_serviceClient.MemberRegister(client)) return;
            MessageBox.Show("Account created successfully!");
            var main = new MainWindow();
            this.Close();
            main.Show();


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



        private void TxtEmail_OnPreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var result = ValidatorExtensions.IsValidEmailAddress(TxtAddress.Text);
            if (result != true) return;
            e.Handled = true;
            MessageBox.Show("E-Mail expected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            TxtAddress.Focus();
        }
    }
}
