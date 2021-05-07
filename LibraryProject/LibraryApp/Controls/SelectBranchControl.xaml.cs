using LibraryApp.DataModel;
using System.Windows;
using System.Windows.Controls;

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for SelectBranchControl.xaml
    /// </summary>
    public partial class SelectBranchControl : UserControl
    {
        public Branch Branch
        {
            get => (Branch)GetValue(BranchProperty);
            set => SetValue(BranchProperty, value);
        }

        public static readonly DependencyProperty BranchProperty =
            DependencyProperty.Register("Branch", typeof(Branch), typeof(SelectBranchControl), new PropertyMetadata(new Branch()
            { Name = "Name", Address = "Address" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is SelectBranchControl control)
            {
                control.NameTextBlock.Text = (e.NewValue as Branch)?.Name;

            }
        }
        public SelectBranchControl()
        {
            InitializeComponent();
        }
    }
}

