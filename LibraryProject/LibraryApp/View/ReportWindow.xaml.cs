using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();

        public ReportWindow(Client client)
        {
            InitializeComponent();
            _client = client;
            var reports = _serviceClient.GetReports();
            ReportsView.ItemsSource = reports;

        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfileWindow = new MyProfilePageAdmin(_client);
            myProfileWindow.Show();
            Close();
        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBook();
            addBookWindow.Show();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var viewMembersWindow = new ViewUsers(_client);
            viewMembersWindow.Show();
            Close();
        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var messageBoxResult =
                MessageBox.Show("Are you sure?", "Logout confirmation", MessageBoxButton.YesNo);

            if (messageBoxResult != MessageBoxResult.Yes) return;
            var main = new MainWindow();
            Close();
            main.Show();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            ReportsView.SelectedItem = lvi.DataContext;
        }

        private void Report_OnClick(object sender, RoutedEventArgs e)
        {
            var reportWindow = new ReportWindow(_client);
            reportWindow.Show();
            Close();
        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var addBranchWindow = new AddBranch(_client);
            addBranchWindow.Show();
            Close();

        }

        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewBranchesWindow = new ViewBranches(_client);
            viewBranchesWindow.Show();
            Close();
        }
    }
}
