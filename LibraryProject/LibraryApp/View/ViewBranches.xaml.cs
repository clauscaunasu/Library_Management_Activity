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
    /// Interaction logic for ViewBranches.xaml
    /// </summary>
    public partial class ViewBranches : Window
    {
        private List<Branch> branches;
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public ViewBranches()
        {
            InitializeComponent();
            branches = _serviceClient.ViewBranches();
            BranchesView.ItemsSource = branches;
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

        private void MyProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewMembersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddBranchBtn_Click(object sender, RoutedEventArgs e)
        {
            var branchPage = new AddBranch();
            branchPage.Show();
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedBranch = BranchesView.SelectedItem as Branch;
            var updateBranchPage = new UpdateBranch(selectedBranch);
            updateBranchPage.Show();

        }
    }
}
