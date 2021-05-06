using System.Windows;
using System.Windows.Input;
using LibraryApp.BusinessLogic;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    public partial class EditMember : Window
    {
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly Encrypter encrypter;
        public EditMember(Client client)
        {

            _client = client;
            InitializeComponent();
            NewTxtFirstname.Text = client.FirstName;
            NewTxtLastname.Text = client.LastName;
            NewTxtEmail.Text = client.Address;
            NewTxtUsername.Text = client.Username;
            NewTxtPassword.Password = client.Password;
            NewTxtPhone.Text = client.Telephone;
            encrypter = new Encrypter();

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
            if (_client.Password == NewTxtPassword.Password)
            {
            }
            else
            {
                _client.Password = encrypter.Encrypt(NewTxtPassword.Password);
            }

            _client.Telephone = NewTxtPhone.Text;

            var isSaved = _serviceClient.EditMember(_client);
            this.DialogResult = true;
            if (isSaved)
            {
                MessageBox.Show("Member edited successfully!");
                this.Close();
            }
        }
    }
}