using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows.Controls;
using LibraryApp.DataModel;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	/*[OperationContract]
	List<string> GetBranches();

    [OperationContract]
    bool LogIn(string username, string password);

    [OperationContract]
    bool Register(string firstName, string lastName, string address, string telephone, string username,string password);

    [OperationContract]
    List<string> BranchListLoader();

    [OperationContract]
    bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies);*/

    [OperationContract]
    bool MemberRegister(Client client);

    [OperationContract]
    Client MemberLogin(Client client);

    [OperationContract]
    List<Client> ClientList();

    [OperationContract]
    bool EditMember(Client client);

    [OperationContract]
    bool DeleteMember(Client client);

    [OperationContract]
    List<Book> BooksList();

    [OperationContract]
    bool EditBook(Book book);

    [OperationContract]
    bool AddBranch(Branch branch);

    [OperationContract]
    List<Branch> ViewBranches();

    [OperationContract]
    bool EditBranch(Branch branch);

    [OperationContract]
    bool DeleteBranch(Branch branch);

    [OperationContract]
    bool AddBook(Book book);

    [OperationContract]
    Client GetClient(Client client);

    [OperationContract]
    bool AddBookInBranch(Book book, string branchName, int quantity);

    [OperationContract]
    bool DeleteBookFromBranch(Book book, string branchName);

    [OperationContract]
    int GetNoCopiesFromBranch(Branch branch, Book book);

    [OperationContract]
    bool BorrowBookFromBranch(Book book, string branchName);

    [OperationContract]
    bool RenewBookFromBranch(Book book, string branchName, Client client);

    [OperationContract]
    bool ReturnBookFromBranch(Book book, string branchName);

    [OperationContract]
    List<Book> GetBooksFromBranch(string branchName);

    [OperationContract]
    List<Branch> BranchesForBook(Book book);

    [OperationContract]
    int GetQuantityOfBook(Book book);

    // TODO: Add your service operations here
}

