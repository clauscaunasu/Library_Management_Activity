using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp_DAL;



// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public partial class Service : IService
{

    private IUserRepository GetUserRepository()
    {
        return new UserRepository(new DConnectivity());
    }

    
    private IBookRepository GetBookRepository()
    {
        return new BookRepository(new DConnectivity());
    }

    private IBranchRepository GetBranchRepository()
    {
        return new BranchRepository(new DConnectivity());
    }

    private IBranchXBookRepository GetBranchXBookRepository()
    {
        return new BranchXBookRepository(new DConnectivity());
    }

    private ILibraryFileRepository GetLibraryFileRepository()
    {
        return new LibraryFileRepository(new DConnectivity());
    }

    private IReportRepository GetReportRepository()
    {
        return new ReportRepository(new DConnectivity());
    }

    public bool EditMember(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.EditMember(client);
    }

    public bool DeleteMember(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.DeleteMember(client);
    }


    public bool MemberRegister(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.Add(client);
    }

    public Client MemberLogin(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.GetUserByNameAndPassword(client.Username, client.Password);

    }

    public List<Client> ClientList()
    {
        var userRepository = GetUserRepository();
        return userRepository.GetClients();
    }
    public List<Book> BooksList()
    {
        var bookRepository = GetBookRepository();
        return bookRepository.GetBooks();
    }

    public bool EditBook(Book book)
    {
        var bookRepository = GetBookRepository();
        return bookRepository.UpdateBook(book);
    }

    public bool AddBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.AddBranch(branch);
    }

    public List<Branch> ViewBranches()
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.GetBranches();
    }

    public bool EditBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.UpdateBranch(branch);
    }

    public bool DeleteBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.DeleteBranch(branch);
    }

    public bool AddBook(Book book)
    {
        var bookRepository = GetBookRepository();
        return bookRepository.AddBook(book);
    }

    public Client GetClient(Client client)
    {
        var clientRep = GetUserRepository();
        return clientRep.GetClient(client);
    }

    public bool AddBookInBranch(Book book, string branchName, int quantity)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.AddBookInBranch(book, branchName, quantity);
    }

    public List<Book> GetBooksFromBranch(string branchName)
    {
        var branchXBookRepo = GetBranchXBookRepository();
        return branchXBookRepo.GetBooksFromBranch(branchName);
    }

    public bool DeleteBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.DeleteBookFromBranch(book, branchName);
    }

    public int GetNoCopiesFromBranch(Branch branch, Book book)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.GetNoCopiesFromBranch(branch, book);
    }

    public bool BorrowBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.BorrowBookFromBranch(book, branchName);
    }


    public bool ReturnBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.ReturnBookFromBranch(book, branchName);
    }

    public List<Branch> BranchesForBook(Book book)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.BranchesForBook(book);
    }

    public int GetQuantityOfBook(Book book)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.GetQuantityOfBook(book);

    }

    public List<LibraryFile> GetLibraryFiles()
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.GetLibraryFiles();
    }

    public bool AddLibraryFile(Client client, Book book, Branch branch)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.AddLibraryFile(client, book, branch);
    }

    public List<Book> GetBorrowedBooks(Client client)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.GetBorrowedBooks(client);
    }

    public bool RenewDueDate(Client client, Book book)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.RenewDueDate(client, book);
    }
    public bool ReturnBook(Client client, Book book)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.ReturnBook(client, book);
    }

    public bool IsReturned(Client client, Book book)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.IsReturned(client, book);
    }

    public List<Book> GetBookHistory(Client client)
    {
        var libraryFileRepository = GetLibraryFileRepository();
        return libraryFileRepository.GetBookHistory(client);
    }

    public List<Report> GetReports()
    {
        var reportRepository = GetReportRepository();
        return reportRepository.GetReports();
    }
}
