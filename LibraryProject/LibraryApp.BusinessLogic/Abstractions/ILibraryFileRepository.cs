using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface ILibraryFileRepository
    {
        bool AddLibraryFile(Client client, Book book, Branch branch);
        List<LibraryFile> GetLibraryFiles();
        List<Book> GetBorrowedBooks(Client client);
        bool RenewDueDate(Client client, Book book);
        bool ReturnBook(Client client, Book book);
        bool IsReturned(Client client, Book book);
    }
}
