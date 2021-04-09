using System.Collections.Generic;
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
    bool Register(string firstName, string lastName, string address, string telephone, string username,
        string password);

    [OperationContract]
    List<string> BranchListLoader();

    [OperationContract]
    bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies);*/

    [OperationContract]
    bool MemberRegister(Client client);

    [OperationContract]
    int MemberLogin(Client client);

    [OperationContract]
    List<Client> ClientList();

    // TODO: Add your service operations here
}

