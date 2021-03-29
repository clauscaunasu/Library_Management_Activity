using System.Windows;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var serviceClient = new ServiceClient();
            var result = serviceClient.GetBranches();

        }
    }
}
