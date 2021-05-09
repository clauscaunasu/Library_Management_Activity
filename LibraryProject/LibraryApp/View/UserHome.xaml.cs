using LibraryApp.DataModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.BusinessLogic;
using LibraryApp.LibraryServiceReference;
using Filters = LibraryApp.DataModel.Enums.Filters;


namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : Window
    {

        private readonly Client client;
        private readonly SearchEngine searchEngine;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public UserHome(Client client)
        {
            this.client = client;
            InitializeComponent();
            var books = _serviceClient.BooksList();
            BooksView.ItemsSource = books;
            searchEngine = new SearchEngine(books);
            
        }

 

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfile = new MyProfilePageUser(client);
            myProfile.Show();
            this.Close();
        }

        private void BookHistoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var bookHistoryWindows = new BookHistoryView(client);
            bookHistoryWindows.Show();
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

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BorrowedBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var borrowedPage = new ViewBorrowedBooks(client);
            borrowedPage.Show();
            Close();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BooksView.SelectedItem = lvi.DataContext;
        }

        private void ButtonBorrow_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var borrowBookPage = new BorrowBook(client,selectedBook);
            borrowBookPage.Show();
        }

        private void ButtonSearch_OnClick(object sender, RoutedEventArgs e)
        {
            var filterButton = (Filters) ComboBoxFilter.SelectedIndex;
            if (filterButton < 0)
            {
                MessageBox.Show("Please select a filter");
            }
            else
            {

                var filter = new SearchFilter {Name = filterButton, Term = SearchTextBox.Text};
                var results = searchEngine.Search(filter);
                BooksView.ItemsSource = results;
                BooksView.Items.Refresh();
            }
        }

        private void ButtonMore_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var morePage = new MoreWindow(selectedBook);
            morePage.Show();
        }
    }
}
