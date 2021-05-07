using LibraryApp.DataModel;
using System.Windows;

namespace LibraryApp.View
{
    public partial class MyProfilePageUser : Window
    {
        private readonly Client _client;

        public MyProfilePageUser(Client client)
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
            Close();
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


        private void BorrowedBooksBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var borrowedBookWindows = new ViewBorrowedBooks(_client);
            borrowedBookWindows.Show();
            this.Close();
            
        }

        private void BookHistoryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var bookHistoryWindow = new BookHistoryView(_client);
            bookHistoryWindow.Show();
            this.Close();
        }

        private void AllBooksBtn_Click(object sender, RoutedEventArgs e)
        {
            var userHome = new UserHome(_client);
            userHome.Show();
            Close();
        }

        private void EditBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditMember(_client);
            editWindow.Closed += EditWindow_Closed;
            editWindow.ShowDialog();
        }

        private void EditWindow_Closed(object sender, System.EventArgs e)
        {
            if ((sender as Window)?.DialogResult != true) return;
            var userHome = new UserHome(_client);
            userHome.Show();
            Close();
        }
    }
}

