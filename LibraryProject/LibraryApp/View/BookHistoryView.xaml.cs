using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for BookHistoryView.xaml
    /// </summary>
    public partial class BookHistoryView : Window
    {
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public BookHistoryView(Client client)
        {
            InitializeComponent();
            _client = client;
            var books = _serviceClient.GetBookHistory(client);
            BooksView.ItemsSource = books;
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfile = new MyProfilePageUser(_client);
            myProfile.Show();
            Close();
        }

        private void BorrowedBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var borrowedBooksWindows = new ViewBorrowedBooks(_client);
            borrowedBooksWindows.Show();
            this.Close();
        }

        private void AllBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var userHomeWindow = new UserHome(_client);
            userHomeWindow.Show();
            this.Close();
        }

        private void HelpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var main = new MainWindow();
                this.Close();
                main.Show();
            }
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BooksView.SelectedItem = lvi.DataContext;
        }

        private void ButtonRenew_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonReturn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
