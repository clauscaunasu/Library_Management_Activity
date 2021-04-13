using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.DataModel;
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

            UserView.ItemsSource = clients;

        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            UserView.SelectedItem = lvi.DataContext;
        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedMember = UserView.SelectedItem as Client;
            var updatedMember = new EditMember(selectedMember);
            updatedMember.Show();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedMember = UserView.SelectedItem as Client;
            var messageBoxResult =
                MessageBox.Show("Are you sure", "Delete confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                bool isDeleted = _serviceClient.DeleteMember(selectedMember);
            }

        }
    }
}