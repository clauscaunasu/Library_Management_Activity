using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    public partial class DeleteBook : Window
    {
        private readonly Book _book;
        private readonly Client _client = new Client();
        private readonly ServiceClient _serviceClient = new ServiceClient();

        public DeleteBook(Book book)
        {
            InitializeComponent();
            _book = book;
            var branches = _serviceClient.ViewBranches();
            SelectBranchComboBox.ItemsSource = branches;
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(SelectBranchComboBox.SelectedItem is Branch selectedBranch))
            {
                MessageBox.Show("Please select a branch");
            }
            else
            {

                var isSuccessful = _serviceClient.DeleteBookFromBranch(_book, selectedBranch.Name);
                if (isSuccessful)
                {
                    MessageBox.Show("Book deleted successfully from branch!");
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
}
