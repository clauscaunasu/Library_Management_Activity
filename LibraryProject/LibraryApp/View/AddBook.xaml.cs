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
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private List<Branch> branches;
        private static int quantity = 0;
        private string quantityStr;
        private Book _book = new Book();
        private ServiceClient _serviceClient = new ServiceClient();
        public AddBook()
        {
            InitializeComponent();
            branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
            
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

        private void BtnAddBook_OnClick(object sender, RoutedEventArgs e)
        {
            quantityStr = TxtCopies.Text;
            quantity += Int16.Parse(quantityStr);
            _book.Title = TxtTitle.Text;
            _book.Author = TxtAuthors.Text;
            _book.Editure = TxtEditure.Text;
            _book.UniqueCode = TxtIsbn.Text;
            var selectedBranch = SelectBranchComboBox.SelectedItem as Branch;
            _serviceClient.AddBookInBranch(_book, selectedBranch.Name, quantity);
        }
    }
}
