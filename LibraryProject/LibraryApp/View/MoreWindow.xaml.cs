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
    /// Interaction logic for MoreWindow.xaml
    /// </summary>
    public partial class MoreWindow : Window
    {
        private ServiceClient _serviceClient = new ServiceClient();
        private Book _book;
        private MoreInformation _info;
        public MoreWindow(Book book)
        {
            InitializeComponent();
            InfoView.ItemsSource = _serviceClient.GetMoreInformation(book);
        }

        private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
