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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public Login()
        {
            InitializeComponent();
        }
        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var result = _serviceClient.LogIn(TxtUsername.Text, TxtPassword.Password);

            MessageBox.Show(result ? "success" : "Failed");
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
