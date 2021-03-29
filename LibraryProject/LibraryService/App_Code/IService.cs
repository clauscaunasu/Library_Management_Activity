using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	List<string> GetBranches();

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{	
    //this is another comment

	bool boolValue = true;
	string stringValue = "Hello World";

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
}
