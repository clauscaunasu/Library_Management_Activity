using LibraryApp.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LibraryApp.BusinessLogic;
using LibraryApp.Controls;
using LibraryApp.LibraryServiceReference;


namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : Window
    {

        private Client client;
        private readonly SearchEngine searchEngine;
        private List<Book> books = new List<Book>();
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public UserHome(Client client)
        {
            this.client = client;
            InitializeComponent();
            books = _serviceClient.BooksList();
            BooksView.ItemsSource = books;
            searchEngine = new SearchEngine(books);
            
        }

 

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BookHistoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HelpBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult =
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
            this.Close();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)sender;
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
    }
}
