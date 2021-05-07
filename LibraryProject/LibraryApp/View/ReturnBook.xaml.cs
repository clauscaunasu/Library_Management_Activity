using System.Windows;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Window
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void OkBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
