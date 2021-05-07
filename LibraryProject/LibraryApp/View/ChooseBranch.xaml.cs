using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;
using System.Windows;
using static System.Int16;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ChooseBranch.xaml
    /// </summary>
    public partial class ChooseBranch : Window
    {
        private int quantity;
        private string quantityStr;
        private readonly Book _book;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public ChooseBranch(Book book)
        {
            InitializeComponent();
            var branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
            _book = book;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            quantityStr = BooksQuantityTxt.Text;
            quantity += Parse(quantityStr);
            var selectedBranch = SelectBranchComboBox.SelectedItem as Branch;
            quantity += _serviceClient.GetNoCopiesFromBranch(selectedBranch, _book);
            var isSuccessful = _serviceClient.AddBookInBranch(_book, selectedBranch?.Name, quantity);
            if(isSuccessful)
            {
                MessageBox.Show("Book added successfully in branch!");
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
