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
    /// Interaction logic for DeleteMember.xaml
    /// </summary>
    public partial class DeleteMember : Window
    {
        private readonly Client _client = new Client();
        private readonly ServiceClient _serviceClient = new ServiceClient();

        public DeleteMember(Client client)
        {
            _client = client;
            InitializeComponent();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var isDeleted = _serviceClient.DeleteMember(_client);
            if (!isDeleted) return;
            MessageBox.Show("Member deleted successfully!");
            var viewMembers = new ViewUsers(_client);
            this.Close();
            viewMembers.Show();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
