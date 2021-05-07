using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;
using System.Windows;
using System.Windows.Input;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for DeleteBranch.xaml
    /// </summary>
    public partial class DeleteBranch : Window
    {
        private readonly Branch _branch;
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public DeleteBranch(Branch branch, Client client)
        {
            InitializeComponent();
            _branch = branch;
            _client = client;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var isDeleted = _serviceClient.DeleteBranch(_branch);
            if (isDeleted)
            {
                MessageBox.Show("Branch deleted successfully!");
                var viewBranchesP = new ViewBranches(_client);
                this.Close();
                viewBranchesP.Show();
            }
            else
            {
                MessageBox.Show("Delete the books from the branch first!");
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
