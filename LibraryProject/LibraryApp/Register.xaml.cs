using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var result = _serviceClient.Register(TxtFirstname.Text, TxtLastname.Text, TxtAddress.Text, TxtPhone.Text,
                   TxtUsername.Text, TxtPassword.Password);
            MessageBox.Show(result ? "success" : "failed");
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        { 
            
        }
    }
}
