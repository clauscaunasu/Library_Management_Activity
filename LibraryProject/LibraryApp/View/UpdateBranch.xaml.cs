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
    /// <summary>
    /// Interaction logic for UpdateBranch.xaml
    /// </summary>
    public partial class UpdateBranch : Window
    {
        private readonly Branch _branch = new Branch();
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public UpdateBranch(Branch branch)
        {
            InitializeComponent();
            _branch = branch;
            NewName.Text = branch.Name;
            NewAddress.Text = branch.Address;
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            bool isSaved = _serviceClient.EditBranch(_branch);
            if (isSaved) return;
            MessageBox.Show("The branch was successfully updated!");
        }
    }
}
