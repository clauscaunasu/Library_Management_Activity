using System.Windows;

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
