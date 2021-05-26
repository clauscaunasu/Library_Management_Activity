using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private readonly Client _client;
        private List<Branch> branches = new List<Branch>();
        public ViewBranches(Client client)
        {
            InitializeComponent();
            branches = _serviceClient.ViewBranches();
            BranchesView.ItemsSource = branches;
            _client = client;
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
            var myProfileWindow = new MyProfilePageAdmin(_client);
            myProfileWindow.Show();
            Close();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var viewMembersWindow = new ViewUsers(_client);
            viewMembersWindow.Show();
            Close();
        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch(_client);
            branchPage.Closed += AddBranch_Close;
            branchPage.ShowDialog();
            BranchesView.Items.Refresh();

        }

        private void AddBranch_Close(object sender, EventArgs e)
        {
            if ((sender as Window)?.DialogResult == true)
            {
                branches = _serviceClient.ViewBranches();
                BranchesView.ItemsSource = null;
                BranchesView.ItemsSource = branches;

            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = BranchesView.SelectedItem as Branch;
            var updateBranchPage = new UpdateBranch(selectedBranch, _client);
            updateBranchPage.Closed += AddBranch_Close;
            updateBranchPage.ShowDialog();
            BranchesView.Items.Refresh();

        }

        
        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            BranchesView.SelectedItem = lvi.DataContext;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = BranchesView.SelectedItem as Branch;
            var deleteBranchPage = new DeleteBranch(selectedBranch, _client);
            deleteBranchPage.Closed += AddBranch_Close;
            deleteBranchPage.ShowDialog();
            BranchesView.Items.Refresh();
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

        private void ViewBooks_OnClick(object sender, RoutedEventArgs e)
        {
            var viewBooksWindow = new AdminHome(_client);
            viewBooksWindow.Show();
            Close();
        }
    }
}
