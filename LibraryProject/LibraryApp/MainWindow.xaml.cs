using System;
using System.Windows;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp
{

    public partial class MainWindow : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public MainWindow()
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
            DragMove();
        }
    }
}
