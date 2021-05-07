using System;
using LibraryApp.DataModel;
using System.Windows;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePageAdmin : Window
    {
        private readonly Client _client;

        public MyProfilePageAdmin(Client client)
        {
            _client = client;
            InitializeComponent();
            DataContext = client;
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


        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var viewUsers = new ViewUsers(_client);
            viewUsers.Show();

        }


        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch(_client);
            branchPage.Show();
        }


        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewBranchesPage = new ViewBranches(_client);
            viewBranchesPage.Show();
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

        private void ViewBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var adminHome = new AdminHome(_client);
            adminHome.Show();
            this.Close();
        }

        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditMember(_client);
            editWindow.Closed += EditWindow_Closed;
            editWindow.ShowDialog();
        }

        private void EditWindow_Closed(object sender, EventArgs e)
        {
            if ((sender as Window)?.DialogResult != true) return;
            var userHome = new UserHome(_client);
            userHome.Show();
            Close();
        }
    }
}

