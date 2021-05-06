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

        public AddBranch()
        {
            InitializeComponent();
        }

        private void BtnAddBranch_Click(object sender, RoutedEventArgs e)
        {
            _branch.Name = TxtName.Text;
            _branch.Address = TxtAddress.Text;
            var isAdded =  _serviceClient.AddBranch(_branch);
            if (isAdded)
            {
                MessageBox.Show("Branch added successfully!");
                this.Close();
                var newBranchP = new ViewBranches();
                newBranchP.Show();
            }


        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
