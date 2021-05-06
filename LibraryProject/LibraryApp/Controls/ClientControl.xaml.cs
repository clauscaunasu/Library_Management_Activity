using System.Windows;
using LibraryApp.DataModel;

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for ClientControl.xaml
    /// </summary>
    public partial class ClientControl
    {
        public Client Client
        {
            get => (Client)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        public static readonly DependencyProperty ContactProperty
            = DependencyProperty.Register("Client", typeof(Client), typeof(ClientControl), new PropertyMetadata(new Client()
            { Username = "Firstname Lastname", Telephone = "(123) 4567890", Address = "Email@YAhoo.com" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ClientControl clientControl)
            {
                clientControl.NameTextBlock.Text = (e.NewValue as Client)?.Username;
                clientControl.EmailTextBlock.Text = (e.NewValue as Client)?.Address;
                clientControl.PhoneTextBlock.Text = (e.NewValue as Client)?.Telephone;
            }
        }

        public ClientControl()
        {
            InitializeComponent();
        }
    }
}