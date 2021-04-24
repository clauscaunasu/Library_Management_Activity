using LibraryApp.DataModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for PersonalInfoControl.xaml
    /// </summary>
    public partial class PersonalInfoControl : UserControl
    {
        public Client Client
        {
            get => (Client)GetValue(PersonalInfoProperty);
            set => SetValue(PersonalInfoProperty, value);
        }

        public static readonly DependencyProperty PersonalInfoProperty
            = DependencyProperty.Register("Client", typeof(Client), typeof(PersonalInfoControl), new PropertyMetadata(new Client()
            { ID = 1, FirstName = "Firstname", LastName="Lastname", Username = "Username", Telephone = "(123) 4567890",
                Address = "Email@YAhoo.com", Desired=true }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PersonalInfoControl personalInfoControl)
            {
                personalInfoControl.EmailTextBlock.Text = (e.NewValue as Client)?.Address;
                personalInfoControl.PhoneTextBlock.Text = (e.NewValue as Client)?.Telephone;
                personalInfoControl.FirstnameTextBlock.Text = (e.NewValue as Client)?.FirstName;
                personalInfoControl.LastnameTextBlock.Text = (e.NewValue as Client)?.LastName;
                personalInfoControl.UsernameTextBlock.Text = (e.NewValue as Client)?.Username;
                personalInfoControl.StatusTextBlock.Text = (e.NewValue as Client)?.Desired.ToString();
            }
        }
        public PersonalInfoControl()
        {
            InitializeComponent();
        }
    }
}
