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

	[OperationContract]
	List<string> GetBranches();

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    bool LogIn(string username, string password);

    [OperationContract]
    bool Register(string firstName, string lastName, string address, string telephone, string username,
        string password);

    [OperationContract]
    List<string> BranchListLoarder();

    [OperationContract]
    bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies);

    [OperationContract]
    int MemberRegister(Client client);

    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{	
    //this is another comment

	bool boolValue = true;
	string stringValue = "Hello";
	int intValue = 1;

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}
	//this is a comment
	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}

    [DataMember]
    public int IntValue
    {
        get { return intValue; }
        set { intValue = value; }
    }
}
