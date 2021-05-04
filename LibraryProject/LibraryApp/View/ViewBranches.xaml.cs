using System;
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
    /// Interaction logic for ViewBranches.xaml
    /// </summary>
    public partial class ViewBranches : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public ViewBranches()
        {
            InitializeComponent();
            var branches = _serviceClient.ViewBranches();
            BranchesView.ItemsSource = branches;
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
            throw new NotImplementedException();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch();
            branchPage.Show();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = BranchesView.SelectedItem as Branch;
            var updateBranchPage = new UpdateBranch(selectedBranch);
            updateBranchPage.Show();

        }
        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BranchesView.SelectedItem = lvi.DataContext;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = BranchesView.SelectedItem as Branch;
            var deleteBranchPage = new DeleteBranch(selectedBranch);
            deleteBranchPage.Show();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

            if (messageBoxResult != MessageBoxResult.Yes) return;
            var main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
