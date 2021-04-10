using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;


namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IBookRepository
    {
        bool AddBookInBranch(Book book, string branchName, int copies);
        Book GetBookById(int id);
        List<Book> ListOfBooks(DataTable dt);
        List<Book> GetBooks();
        bool DeleteBook(Book book);
        bool UpdateBook(Book book);


    }
}
