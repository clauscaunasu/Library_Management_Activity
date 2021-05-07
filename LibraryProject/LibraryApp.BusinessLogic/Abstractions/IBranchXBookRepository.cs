using System.Collections.Generic;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IBranchXBookRepository
    {
        bool AddBookInBranch(Book book, string branchName,int quantity);
        bool DeleteBookFromBranch(Book book, string branchName);
        int GetNoCopiesFromBranch(Branch branch, Book book);
        bool BorrowBookFromBranch(Book book, string branchName);
        bool ReturnBookFromBranch(Book book, string branchName);
        List<Book> GetBooksFromBranch(string branchName);
        List<Branch> BranchesForBook(Book book);
        int GetQuantityOfBook(Book book);
    }
}
