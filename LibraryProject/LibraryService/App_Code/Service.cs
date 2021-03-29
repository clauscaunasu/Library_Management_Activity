using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public List<string> GetBranches()
    {
        var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(string.Empty, connection);
            command.Connection.Open();
            command.CommandText = "select count(*) from Branch";
            var result = command.ExecuteScalar();

            return new List<string>();
        }
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
