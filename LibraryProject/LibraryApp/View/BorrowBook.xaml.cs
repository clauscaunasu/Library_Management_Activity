using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : Window
    {
        private List<Branch> branches;
        private Book _book;
        private List<Book> _borrowedBooks = new List<Book>();
        private Client _client;
        private ServiceClient _serviceClient = new ServiceClient();
        public BorrowBook(Client client,Book book)
        {
            InitializeComponent();
            branches = _serviceClient.BranchesForBook(book);
            SelectBranchComboBox.ItemsSource = branches;
            _book = book;
            _client = client;
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BorrowBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = SelectBranchComboBox.SelectedItem as Branch;

            _borrowedBooks = _serviceClient.GetBorrowedBooks(_client);

            var isSuccessful = _borrowedBooks.Count <= 3 && _serviceClient.AddLibraryFile(_client, _book, selectedBranch);
            
            if (isSuccessful)
            {
                MessageBox.Show("Book borrowed successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong, please try again");
                this.Close();
            }
        }

    }
}
