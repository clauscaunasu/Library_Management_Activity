using System.Windows;
using System.Windows.Input;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : Window
    {
        private readonly Branch _branch;
        private readonly Client _client;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public UpdateBranch(Branch branch, Client client)
        {
            InitializeComponent();
            _branch = branch;
            NewName.Text = branch.Name;
            NewAddress.Text = branch.Address;
            _client = client;
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            _branch.Name = NewName.Text;
            _branch.Address = NewAddress.Text;
            var isSaved = _serviceClient.EditBranch(_branch);
            this.DialogResult = true;
            if (!isSaved) return;
            MessageBox.Show("Branch updated successfully!");

        }
    }
}
