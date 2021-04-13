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
    /// Interaction logic for BookControl.xaml
    /// </summary>
    public partial class BookControl : UserControl
    {

        public Book Book
        {
            get => (Book) GetValue(BookProperty);
            set => SetValue(BookProperty, value);
        }
        
        public static readonly DependencyProperty BookProperty = 
            DependencyProperty.Register("Book", typeof(Book),typeof(BookControl),new PropertyMetadata(new Book()
                {Title = "Title",UniqueCode = "ISBN",Author = "Author",Editure = "Publisher"},SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BookControl control = d as BookControl;
            if (control != null)
            {
                control.TitleTextBlock.Text = (e.NewValue as Book).Title;
                control.IsbnTextBlock.Text = (e.NewValue as Book).UniqueCode;
                control.AuthorTextBlock.Text = (e.NewValue as Book).Author;
                control.EditureTextBlock.Text = (e.NewValue as Book).Editure;

            }
        }
        public BookControl()
        {
            InitializeComponent();
        }
    }
}
