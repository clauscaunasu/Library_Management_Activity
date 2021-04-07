using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp_DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DConectivity connection;
        public UserRepository(DConectivity connection)
        {
            this.connection = connection;
        }
        public bool Add(Client client)
        {
           var command = connection.dbCommand(
                "INSERT INTO Client(FirstName, LastName, Address, Telephone, Username, Password)" +
                " VALUES (@firstName, @lastName, @address, @telephone, @username, @password)");

            command.Parameters.AddWithValue("@username", client.Username);
            command.Parameters.AddWithValue("@password", client.Password);
            command.Parameters.AddWithValue("@telephone", client.Telephone);
            command.Parameters.AddWithValue("@address", client.Address);
            command.Parameters.AddWithValue("@lastName", client.LastName);
            command.Parameters.AddWithValue("@firstName", client.FirstName);


            return command.ExecuteNonQuery() == 1;
        }

        public Client GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Client GetUserByNameAndPassword(string name, string password)
        {
            throw new NotImplementedException();
        }
    }
}
