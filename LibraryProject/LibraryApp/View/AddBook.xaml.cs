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
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        public AddBook()
        {
            InitializeComponent();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnAddBook_OnClick(object sender, RoutedEventArgs e)
        {
            //var result = _serviceClient.AddBook(TxtTitle.Text, TxtIsbn.Text, TxtAuthors.Text, TxtEditure.Text,
            //    TxtBranch.Text, int.Parse(TxtCopies.Text));
            //MessageBox.Show(result ? "success" : "failed");
        }
    }
}
