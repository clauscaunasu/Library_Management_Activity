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
using LibraryApp.DataModel;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        private Branch _branch = new Branch();

        public AddBranch()
        {
            InitializeComponent();
        }

        private void BtnAddBranch_Click(object sender, RoutedEventArgs e)
        {
            _branch.Name = TxtName.Text;
            _branch.Address = TxtAddress.Text;
            bool isAdded =  _serviceClient.AddBranch(_branch);
            if (!isAdded) return;
            MessageBox.Show("Branch added successfully!");


        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
