using System.Windows;
using System.Windows.Controls;
using LibraryApp.DataModel;

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for BranchControl.xaml
    /// </summary>
    public partial class BranchControl : UserControl
    {
        public Branch Branch
        {
            get => (Branch)GetValue(BranchProperty);
            set => SetValue(BranchProperty, value);
        }

        public static readonly DependencyProperty BranchProperty =
            DependencyProperty.Register("Branch", typeof(Branch), typeof(BranchControl), new PropertyMetadata(new Branch()
            { Name = "Name", Address = "Address"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is BranchControl control)) return;
            control.NameTextBlock.Text = (e.NewValue as Branch)?.Name;
            control.AddressTextBlock.Text = (e.NewValue as Branch)?.Address;
        }
        public BranchControl()
        {
            InitializeComponent();
        }
    }
}
