using System;
using System.Windows;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;
using MaterialDesignThemes.Wpf;

namespace LibraryApp
{

    public partial class MainWindow : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void BtnGoToLogin_OnClick(object sender, RoutedEventArgs e)
        {

            Login loginWindow = new Login();
            loginWindow.ShowDialog(true);

        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.ShowDialog(true);

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
