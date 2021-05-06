using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;
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

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePageAdmin : Window
    {
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
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
            var branchPage = new AddBranch();
            branchPage.Show();
        }


        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            var viewBranchesPage = new ViewBranches();
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
    }
}

