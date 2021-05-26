using LibraryApp.LibraryServiceReference;
using System.Windows;
using LibraryApp.DataModel;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : Window
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private readonly Branch _branch = new Branch();
        private readonly Client _client;

        public AddBranch(Client client)
        {
            InitializeComponent();
            _client = client;
            
        }

        private void BtnAddBranch_Click(object sender, RoutedEventArgs e)
        {
            _branch.Name = TxtName.Text;
            _branch.Address = TxtAddress.Text;
            var isAdded =  _serviceClient.AddBranch(_branch);
            this.DialogResult = true;
            if (isAdded)
            {
                MessageBox.Show("Branch added successfully!");
                Close();
                //var newBranchP = new ViewBranches(_client);
                //newBranchP.Show();
            }


        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
