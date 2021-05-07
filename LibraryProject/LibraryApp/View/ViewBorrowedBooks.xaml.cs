using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ViewBorrowedBooks.xaml
    /// </summary>
    public partial class ViewBorrowedBooks : Window
    {
        private readonly List<Book> _books;
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public ViewBorrowedBooks(Client client)
        {
            InitializeComponent();
            _client = client;
            _books = _serviceClient.GetBorrowedBooks(_client);
            BooksView.ItemsSource = _books;
        }
        

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfileWindow = new MyProfilePageUser(_client);
            myProfileWindow.Show();
            Close();
        }

        private void BookHistoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var bookHistoryWindows = new BookHistoryView(_client);
            bookHistoryWindows.Show();
            Close();
        }

        private void HelpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

            if (messageBoxResult != MessageBoxResult.Yes) return;
            var main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BooksView.SelectedItem = lvi.DataContext;
        }


        private void AllBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var userPage = new UserHome(_client);
            userPage.Show();
        }

        private void ButtonRenew_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var isRenewed =_serviceClient.RenewDueDate(_client, selectedBook);
            MessageBox.Show(isRenewed ? "Book was successfully renewed with 7 days" : "No more renews are allowed!");
        }

        private void ButtonReturn_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var isReturned = _serviceClient.ReturnBook(_client, selectedBook);
            if (isReturned)
            {
                MessageBox.Show("You can return the book anytime by tomorrow");
                BooksView.Items.Refresh();
                _books.Remove(selectedBook);
                BooksView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again!");
            }
        }
    }
}
