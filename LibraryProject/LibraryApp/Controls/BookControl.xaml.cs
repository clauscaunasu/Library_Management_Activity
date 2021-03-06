using System;
using System.Windows;
using System.Windows.Controls;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.Controls
{
    public partial class BookControl : UserControl
    {
        public Book Book
        {
            get => (Book) GetValue(BookProperty);
            set => SetValue(BookProperty, value);
        }


        public static readonly DependencyProperty BookProperty = 
            DependencyProperty.Register("Book", typeof(Book),typeof(BookControl),new PropertyMetadata(new Book()
                {Title = "Title",UniqueCode = "ISBN",Author = "Author",Editure = "Publisher", Genre = "genre"},SetText));



        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            if (d is BookControl control)
            {
                control.TitleTextBlock.Text = (e.NewValue as Book)?.Title;
                control.IsbnTextBlock.Text = (e.NewValue as Book)?.UniqueCode;
                control.AuthorTextBlock.Text = (e.NewValue as Book)?.Author;
                control.EditureTextBlock.Text = (e.NewValue as Book)?.Editure;
                control.GenreTextBlock.Text = (e.NewValue as Book)?.Genre;
            }
        }
        public BookControl()
        {
            InitializeComponent();
            
        }
    }
}
