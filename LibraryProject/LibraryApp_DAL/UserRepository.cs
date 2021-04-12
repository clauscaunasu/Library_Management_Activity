using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using static System.Boolean;


namespace LibraryApp_DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DConectivity _connection;
        public UserRepository(DConectivity connection)
        {
            this._connection = connection;
        }


        public bool EditMember(Client client)
        {

            var command = _connection.dbCommand("UPDATE Client SET FirstName=@firstName, LastName=@lastName, Email=@email, Username=@username, Password=@password" +
                " Telephone=@telephone, Address=@address) WHERE (ID= @id)");

            command.Parameters.AddWithValue("@firstName", client.FirstName);
            command.Parameters.AddWithValue("@lastName", client.LastName);
            command.Parameters.AddWithValue("@username", client.Username);
            command.Parameters.AddWithValue("@password", client.Password);
            command.Parameters.AddWithValue("@telephone", client.Telephone);
            command.Parameters.AddWithValue("@address", client.Address);


            return command.ExecuteNonQuery() == 1;

        }

        public bool DeleteMember(Client client)
        {
            var command = _connection.dbCommand("DELETE Client WHERE (ID= @id)");

            return command.ExecuteNonQuery() == 1;
        }
        public bool Add(Client client)
        {
           var command = _connection.dbCommand(
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
            var client = new Client();
            
            var command = _connection.dbCommand( "SELECT COUNT(1) FROM Client WHERE ID = @ID");
            command.Parameters.AddWithValue("@ID", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    client.FirstName = reader["FirstName"].ToString();
                    client.LastName = reader["LastName"].ToString();
                    client.Address = reader["Address"].ToString();
                    client.Duty = reader["Duty"].ToString();
                    client.Username = reader["Username"].ToString();
                    client.Password = reader["Password"].ToString();
                    client.Desired = Parse(reader["Desired"].ToString());
                }
            }
            return client;
        }

        public Client GetUserByNameAndPassword(string username, string password)
        {
            var client = new Client();
            var command = _connection.dbCommand("SELECT COUNT(1) FROM Client WHERE Username = @Username " +
                                               "AND Password = @Password");
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                client.FirstName = reader["FirstName"].ToString();
                client.LastName = reader["LastName"].ToString();
                client.Address = reader["Address"].ToString();
                client.Telephone = reader["Telephone"].ToString();
                client.Duty = reader["Duty"].ToString();
                client.Username = reader["Username"].ToString();
                client.Password = reader["Password"].ToString();
                client.Desired = Parse(reader["Desired"].ToString());

                /*client.FirstName = reader.GetString(1);
                client.LastName = reader.GetString(2);
                client.Address = reader.GetString(3);
                client.Duty = reader.GetString(4);
                client.Username = reader.GetString(5);
                client.Password = reader.GetString(6);
                client.Desired = Parse(reader.GetString(7));*/
            }
            reader.Close();
            return client;
        }
    }


}
