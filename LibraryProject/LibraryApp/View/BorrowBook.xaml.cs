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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : Window
    {
        public BorrowBook()
        {
            InitializeComponent();
        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BorrowBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var confirmationWindow = new BorrowConfirmation();
            confirmationWindow.Show();
            this.Close();
        }
    }
}
