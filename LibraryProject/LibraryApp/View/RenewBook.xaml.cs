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
    /// Interaction logic for RenewBook.xaml
    /// </summary>
    public partial class RenewBook : Window
    {
        public RenewBook()
        {
            InitializeComponent();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
