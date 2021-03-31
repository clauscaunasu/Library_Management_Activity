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
            this.Visibility = Visibility.Hidden;
            loginWindow.Show();
        }

        private void BtnRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterUser();
            this.Visibility = Visibility.Hidden;
            registerWindow.Show();

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
