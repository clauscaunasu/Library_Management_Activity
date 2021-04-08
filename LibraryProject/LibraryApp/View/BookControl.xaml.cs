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
        private Book book;

        public Book Book
        {
            get => book;
            set
            {
                book = value;
                NameTextBlock.Text = book.Title;
                phoneTextBlock.Text = book.Author;

            }
        }
        public BookControl()
        {
            InitializeComponent();
        }
    }
}
