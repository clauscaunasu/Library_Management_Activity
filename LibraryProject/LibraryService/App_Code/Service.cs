﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ConfigurationManager = System.Configuration.ConfigurationManager;

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

    public bool Register(string firstName, string lastName, string address, string telephone, string username, string password)
    {
        var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(string.Empty, connection);
            command.Connection.Open();
            command.CommandText = "INSERT INTO Client(FirstName, LastName, Address, Telephone, Username, Password)" +
                                  " VALUES ('" + firstName + "' , '" + lastName + "' , '" +
                                  address + "' , '" + telephone +
                                  "' , '" + username + "' , '" + password + "')";

            return command.ExecuteNonQuery() == 1;
        }
    }

    public bool LogIn(string username, string password)
    {
        var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(string.Empty, connection);
            command.Connection.Open();
            command.CommandText = "SELECT COUNT(1) FROM Client WHERE Username = '" +
                                  username + "' AND Password ='" +
                                  password + "'";
            var result = (int)command.ExecuteScalar();
            return result == 1;
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
