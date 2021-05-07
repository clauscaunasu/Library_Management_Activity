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
    public partial class RegisterUser : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly Encrypter enc = new Encrypter();
        private readonly Client client = new Client();
         

        public RegisterUser()
        {
            InitializeComponent();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {

            client.FirstName = TxtFirstname.Text;
            client.LastName = TxtLastname.Text;
            client.Telephone = TxtPhone.Text;
            client.Username = TxtUsername.Text;
            client.Address = TxtEmail.Text;
            client.Password = enc.Encrypt(TxtPassword.Password);


            if (string.IsNullOrEmpty(TxtFirstname.Text) || string.IsNullOrEmpty(TxtLastname.Text) || string.IsNullOrEmpty(TxtEmail.Text) ||
                string.IsNullOrEmpty(TxtPhone.Text) || string.IsNullOrEmpty(TxtUsername.Text) || string.IsNullOrEmpty(TxtPassword.Password))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (ValidatorExtensions.IsValidEmailAddress(TxtEmail.Text))
                {
                    if (!_serviceClient.MemberRegister(client)) return;
                    MessageBox.Show("Account created successfully!");
                    var main = new MainWindow();
                    this.Close();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
