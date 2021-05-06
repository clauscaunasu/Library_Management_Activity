using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryApp.BusinessLogic.SearchFilters;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    public partial class ViewUsers : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly List<Client> clients;
        private readonly SearchClientByName searchBranch;
        private readonly Client _client;

        public ViewUsers(Client client)
        {
            InitializeComponent();
            clients = _serviceClient.ClientList();
            UserView.ItemsSource = clients;
            searchBranch = new SearchClientByName(clients);
            _client = client;


        }

        private void BtnExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lvi = (ListViewItem)sender;
            UserView.SelectedItem = lvi.DataContext;
        }

        private void ButtonUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedMember = UserView.SelectedItem as Client;
            var updatedMember = new EditMember(selectedMember);
            updatedMember.Closed += UpdatedMember_Closed;
            updatedMember.ShowDialog();
            UserView.Items.Refresh();
        }

        private void UpdatedMember_Closed(object sender, System.EventArgs e)
        {
            if ((sender as Window)?.DialogResult == true)
            {
                UserView.ItemsSource = clients;
            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedMember = UserView.SelectedItem as Client;
            var messageBoxResult =
                MessageBox.Show("Are you sure", "Delete confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult != MessageBoxResult.Yes) return;
            var isDeleted = _serviceClient.DeleteMember(selectedMember);
            clients.Remove(selectedMember);
            UserView.Items.Refresh();
        }

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            var myProfile = new MyProfilePageAdmin(_client);
            this.Close();
            myProfile.Show();
        }
        
        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ViewBranchesBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
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

        private void ViewBookBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var homeAdmin = new AdminHome(_client);
            this.Close();
            homeAdmin.Show();
        }

 

        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            var results = searchBranch.Search(TextBoxSearch.Text.ToLowerInvariant());
            UserView.ItemsSource = results;
            UserView.Items.Refresh();
        }
    }
}