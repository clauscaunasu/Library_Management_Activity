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
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    public partial class EditMember : Window
    {
        private readonly Client _client = new Client();
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public EditMember(Client client)
        {

            _client = client;
            InitializeComponent();
            NewTxtFirstname.Text = client.FirstName;
            NewTxtLastname.Text = client.LastName;
            NewTxtEmail.Text = client.Address;
            NewTxtUsername.Text = client.Username;
            NewTxtPassword.Text = client.Password;
            NewTxtPhone.Text = client.Telephone;

        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            _client.FirstName = NewTxtFirstname.Text;
            _client.LastName = NewTxtLastname.Text;
            _client.Address = NewTxtEmail.Text;
            _client.Username = NewTxtUsername.Text;
            _client.Password = NewTxtUsername.Text;
            _client.Telephone = NewTxtPhone.Text;

            bool isSaved = _serviceClient.EditMember(_client);
            if (isSaved)
            {
                MessageBox.Show("Member edited successfully!");
                var usersPage = new ViewUsers();
                this.Close();
                usersPage.Show();
            }
        }
    }
}