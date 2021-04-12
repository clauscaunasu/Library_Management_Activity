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
using System.Windows.Shapes;
using LibraryApp.DataModel;
using LibraryApp.LibraryServiceReference;

namespace LibraryApp.View
{
    /// <summary>
    /// Interaction logic for UpdateBook.xaml
    /// </summary>
    public partial class UpdateBook : Window
    {
        private readonly Book _book = new Book();
        private readonly ServiceClient _serviceClient = new ServiceClient();
        public UpdateBook(Book book)
        {
            
            _book = book;
            InitializeComponent();
            NewTitle.Text = book.Title;
            NewAuthors.Text = book.Author;
            NewEditure.Text = book.Editure;
            NewUniqueCode.Text = book.UniqueCode;

        }
        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            _book.Title = NewTitle.Text;
            _book.UniqueCode = NewUniqueCode.Text;
            _book.Editure = NewEditure.Text;
            _book.Author = NewAuthors.Text;
            bool isSaved = _serviceClient.EditBook(_book);
            if (isSaved)
            {
                MessageBox.Show("Book updated successfully!");
                var adminPage = new AdminHome();
                this.Close();
                adminPage.Show();
            }
        }
    }
}
