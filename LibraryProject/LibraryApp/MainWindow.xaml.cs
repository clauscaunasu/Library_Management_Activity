using System;
using System.Windows;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var serviceClient = new ServiceClient();
            var result = serviceClient.GetBranches();

        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
