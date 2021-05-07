using System.Windows;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;
using LibraryApp.LibraryServiceReference;
using static System.Int16;

namespace LibraryApp.View
{

    public partial class AddBook : Window
    {
        private static int _quantity;
        private string quantityStr;
        private readonly Book _book = new Book();
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public AddBook()
        {
            InitializeComponent();
            var branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
            
        }


        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddBook_OnClick(object sender, RoutedEventArgs e)
        {
            quantityStr = TxtCopies.Text;
            _quantity += Parse(quantityStr);
            _book.Title = TxtTitle.Text;
            _book.Author = TxtAuthors.Text;
            _book.Editure = TxtEditure.Text;
            _book.UniqueCode = TxtIsbn.Text;
            _book.Genre = GenresComboBox.Text;
            var isSuccessful = SelectBranchComboBox.SelectedItem is Branch selectedBranch && _serviceClient.AddBookInBranch(_book, selectedBranch.Name, _quantity);
            this.DialogResult = true;
            if(isSuccessful)
            {
                MessageBox.Show("Book added successfully!");
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
