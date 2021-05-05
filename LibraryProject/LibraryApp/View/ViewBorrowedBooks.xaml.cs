using System;
using System.Collections.Generic;
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
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ViewBorrowedBooks.xaml
    /// </summary>
    public partial class ViewBorrowedBooks : Window
    {
        private List<Book> _books = new List<Book>();
        private Client _client;
        private ServiceClient _serviceClient = new ServiceClient();
        public ViewBorrowedBooks(Client client)
        {
            InitializeComponent();
            _client = client;
            _books = _serviceClient.GetBorrowedBooks(_client);
            foreach (var b in _books)
            {
                if (!_serviceClient.IsReturned(_client,b))
                {
                    BooksView.Items.Add(b);
                }
            }
            
            
            BooksView.Items.Refresh();
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
            if (isRenewed)
                MessageBox.Show("Book was successfully renewed with 7 days");
            else
            {
                MessageBox.Show("No more renews are allowed!");
            }

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
