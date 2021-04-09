using System;
using System.Collections.Generic;
using System.Data;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using static System.Boolean;


namespace LibraryApp_DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DConectivity _connection;
        private List<Client> clients = new List<Client>();
        public UserRepository(DConectivity connection)
        {
            this._connection = connection;
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

        public List<Client> GetUserById(int id)
        {
            var client = new Client();
            
            var command = _connection.dbCommand( "SELECT COUNT(1) FROM Client WHERE ID = @ID");
            command.Parameters.AddWithValue("@ID", id);
            var dt = new DataTable();
            var reader = command.ExecuteReader();
            dt.Load(reader);
            ClientList(dt);
            return clients;
        }

        public int GetUserByNameAndPassword(string username, string password)
        {
            var client = new Client();
            var command = _connection.dbCommand("SELECT Duty FROM Client WHERE Username = @Username " +
                                                "AND Password = @Password");
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            return dt.Rows.Count > 0 ? dt.Rows[0]["Duty"].ToString() == "Client" ? 0 : 1 : -1;
        }

        public List<Client> GetClients()
        {
            var command = _connection.dbCommand("SELECT * FROM CLIENT");
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ClientList(dt);
            return clients;
        }

        private void ClientList(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var client = new Client()
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    LastName = dt.Rows[i]["LastName"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Telephone = dt.Rows[i]["Telephone"].ToString(),
                    Duty = dt.Rows[i]["Duty"].ToString(),
                    Username = dt.Rows[i]["Username"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    Desired = Parse(dt.Rows[i]["Desired"].ToString())
                };

                clients.Add(client);
            }
        }
    }
}
