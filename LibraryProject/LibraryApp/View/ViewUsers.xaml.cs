using System.Windows;
using System.Windows.Input;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();

        public ViewUsers()
        {
            InitializeComponent();

            var clients = _serviceClient.ClientList();

            MembersListView.ItemsSource = clients;

        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
