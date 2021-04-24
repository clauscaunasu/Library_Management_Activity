using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataModel;

namespace LibraryApp.BusinessLogic.Abstractions
{
    public interface IBranchXBookRepository
    {
        bool AddBookInBranch(Book book, string branchName,int quantity);
        bool DeleteBookFromBranch(Book book, string branchName);
        int GetNoCopiesFromBranch(Branch branch, Book book);
    }
}
