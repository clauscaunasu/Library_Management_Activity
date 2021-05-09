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

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for MoreControl.xaml
    /// </summary>
    public partial class MoreControl : UserControl
    {
        public MoreInformation MoreInformation
        {
            get => (MoreInformation)GetValue(InformationProperty);
            set => SetValue(InformationProperty, value);
        }


        public static readonly DependencyProperty InformationProperty =
            DependencyProperty.Register("MoreInformation", typeof(MoreInformation), typeof(MoreControl), new PropertyMetadata(new MoreInformation()
                { BranchName = "Name", QuantityInBranch = 0 }, SetText));



        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is MoreControl control)
            {
                control.BranchNameTextBlock.Text = (e.NewValue as MoreInformation)?.BranchName;
                control.QuantityTextBlock.Text = (e.NewValue as MoreInformation)?.QuantityInBranch.ToString();

            }
        }
        public MoreControl()
        {
            InitializeComponent();

        }
    }
}