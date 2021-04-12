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
    /// Interaction logic for DeleteBranch.xaml
    /// </summary>
    public partial class DeleteBranch : Window
    {
        private Branch _branch = new Branch(); 
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public DeleteBranch(Branch branch)
        {
            _branch = branch;
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            bool isDeleted = _serviceClient.DeleteBranch(_branch);
            if (isDeleted)
            {
                MessageBox.Show("Branch deleted successfully!");
                var viewBranchesP = new ViewBranches();
                this.Close();
                viewBranchesP.Show();
            }
            else
            {
                MessageBox.Show("Delete the books from the branch first!");
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
