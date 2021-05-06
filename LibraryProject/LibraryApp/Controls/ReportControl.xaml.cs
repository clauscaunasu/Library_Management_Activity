using System;
using System.Windows;
using System.Windows.Controls;
using LibraryApp.DataModel;

namespace LibraryApp.Controls
{
    /// <summary>
    /// Interaction logic for ReportControl.xaml
    /// </summary>
    public partial class ReportControl : UserControl
    {

        public Report Report
        {
            get => (Report)GetValue(ReportProperty);
            set => SetValue(ReportProperty, value);
        }

        public static readonly DependencyProperty ReportProperty
            = DependencyProperty.Register("Report", typeof(Report), typeof(ReportControl), new PropertyMetadata(new Report()
                { ClientName = "Firstname Lastname", BranchName = "(123) 4567890", BookName = "Email@YAhoo.com", BorrowDate = DateTime.MaxValue, ReturnDate = DateTime.MinValue}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ReportControl reportControl)
            {
                reportControl.ClientName.Text = (e.NewValue as Report)?.ClientName;
                reportControl.BranchName.Text = (e.NewValue as Report)?.BranchName;
                reportControl.BookTitle.Text = (e.NewValue as Report)?.ClientName;
                reportControl.BorrowDate.Text = (e.NewValue as Report)?.BorrowDate.ToShortDateString();
                reportControl.ReturnDate.Text = (e.NewValue as Report)?.ReturnDate.ToShortDateString();
            }
        }
        public ReportControl()
        {
            InitializeComponent();
        }
    }
}
