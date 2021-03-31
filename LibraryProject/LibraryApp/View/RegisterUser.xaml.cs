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
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for RegisterUser.xaml
    /// </summary>
    public partial class RegisterUser : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public RegisterUser()
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
            this.DragMove();
        }
    }
}
