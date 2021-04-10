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
using LibraryApp.DataModel;

namespace LibraryApp.View
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
            BranchControl control = d as BranchControl;
            if (control != null)
            {
                control.NameTextBlock.Text = (e.NewValue as Branch).Name;
                control.AddressTextBlock.Text = (e.NewValue as Branch).Address;

            }
        }
        public BranchControl()
        {
            InitializeComponent();
        }
    }
}
