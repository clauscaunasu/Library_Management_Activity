using System.Windows;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;
using MaterialDesignThemes.Wpf;


namespace LibraryApp.View
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
            var loginWindow = new LoginUser();
            loginWindow.Show();
            this.Close();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterUser();
            registerWindow.Show();
            this.Close();

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
