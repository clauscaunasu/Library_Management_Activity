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
        private ServiceClient _serviceClient = new ServiceClient();
        public BorrowBook(Book book)
        {
            InitializeComponent();
            branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
            _book = book;
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)sender;
            SelectBranchComboBox.SelectedItem = lvi.DataContext;
        }

        private void BorrowBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = SelectBranchComboBox.SelectedItem as Branch;

            var isSuccessful = _serviceClient.BorrowBookFromBranch(_book, selectedBranch.Name);

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
