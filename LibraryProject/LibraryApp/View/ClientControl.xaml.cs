using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows;
using System.Windows.Controls;
using LibraryApp.DataModel;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for ClientControl.xaml
    /// </summary>
    public partial class ClientControl : System.Windows.Controls.UserControl
    {
        private Client _client;

        public Client Client
        {
            get => (Client) GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        public static readonly DependencyProperty ContactProperty 
            = DependencyProperty.Register("Client", typeof(Client), typeof(ClientControl), new PropertyMetadata(new Client()
            {Username = "Firstname Lastname", Telephone = "(123) 4567890", Address = "Email@YAhoo.com"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var clientControl = d as ClientControl;

            if (clientControl != null)
            {
                clientControl.NameTextBlock.Text = (e.NewValue as Client).FirstName;
                clientControl.EmailTextBlock.Text = (e.NewValue as Client).Address;
                clientControl.PhoneTextBlock.Text = (e.NewValue as Client).Telephone;
            }
        }

        public ClientControl()
        {
            InitializeComponent();
        }
    }
}
