using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        private Client _client;
        private List<Book> _books;
        private readonly ServiceClient _serviceClient = new ServiceClient();

        public AdminHome(Client client)
        {
            this._client = client;
            InitializeComponent();
            _books = _serviceClient.BooksList();
            BooksView.ItemsSource = _books;
        }


        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var addBookPage = new AddBook();
            addBookPage.Show();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfilePage = new MyProfilePage(_client);
            myProfilePage.Show();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var viewUsers = new ViewUsers();
            viewUsers.Show();

        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var deleteBookPage = new DeleteBook();
            deleteBookPage.Show();

        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var updateBookPage = new UpdateBook(selectedBook);
            updateBookPage.Closed += UpdateBookPage_Closed;
            updateBookPage.ShowDialog();
            BooksView.Items.Refresh();

        }

        private void UpdateBookPage_Closed(object sender, EventArgs e)
        {
            if ((sender as Window)?.DialogResult == true)
            {
                BooksView.ItemsSource = _books;
            }

        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch();
            branchPage.Show();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BooksView.SelectedItem = lvi.DataContext;
        }

        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewBranchesPage = new ViewBranches();
            viewBranchesPage.Show();
        }

        private void ButtonAddInBranch_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BooksView.SelectedItem as Book;
            var selectBranchPage = new ChooseBranch(selectedBook);
            selectBranchPage.Show();
        }
    }
}
