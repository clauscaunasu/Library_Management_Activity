using System;
using System.Collections.Generic;
using System.Data;
using LibraryApp.BusinessLogic;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using static System.Boolean;


namespace LibraryApp_DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DConnectivity _connection;
        private readonly List<Client> _clients = new List<Client>();
        private Encrypter encrypter = new Encrypter();
        public UserRepository(DConnectivity connection)
        {
            this._connection = connection;
        }


        public bool EditMember(Client client)
        {

            var command = _connection.DbCommand("UPDATE Client SET FirstName=@firstName, LastName=@lastName, Username=@username, Password=@password," +
                " Telephone=@telephone, Address=@address WHERE ID= @id");

            command.Parameters.AddWithValue("@id", client.ID);
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
            var command = _connection.DbCommand("DELETE Client WHERE (ID= @id)");
            command.Parameters.AddWithValue("@id", client.ID);
            return command.ExecuteNonQuery() == 1;
        }
        public bool Add(Client client)
        {
           var command = _connection.DbCommand(
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
            var command = _connection.DbCommand( "SELECT COUNT(1) FROM Client WHERE ID = @ID");
            command.Parameters.AddWithValue("@ID", id);
            var dt = new DataTable();
            var reader = command.ExecuteReader();
            dt.Load(reader);
            ClientList(dt);
            command.Connection.Close();
            return _clients;
            
        }

        public Client GetUserByNameAndPassword(string username, string password)
        {
            var command = _connection.DbCommand("SELECT * FROM Client WHERE Username = @Username " +
                                                "AND Password = @Password");
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ClientList(dt);
            command.Connection.Close();
            return _clients.Count == 0 ? null : _clients[0];
        }

        public List<Client> GetClients()
        {
            var command = _connection.DbCommand("SELECT * FROM CLIENT");
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ClientList(dt);
            command.Connection.Close();
            return _clients;
        }

        public Client GetClient(Client client)
        {
            var command = _connection.dbCommand("SELECT * FROM Client WHERE ID=@id");
            command.Parameters.AddWithValue("@id", client.ID);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            _client.ID = Int32.Parse(dt.Rows[0]["ID"].ToString());
            _client.FirstName = dt.Rows[0]["FirstName"].ToString();
            _client.LastName = dt.Rows[0]["LastName"].ToString();
            _client.Address = dt.Rows[0]["Address"].ToString();
            _client.Telephone = dt.Rows[0]["Telephone"].ToString();
            _client.Duty = dt.Rows[0]["Duty"].ToString();
            _client.Username = dt.Rows[0]["Username"].ToString();
            _client.Password = dt.Rows[0]["Password"].ToString();
            _client.Desired = Parse(dt.Rows[0]["Desired"].ToString());

            return _client;
        }

        private void ClientList(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var client = new Client()
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    LastName = dt.Rows[i]["LastName"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Telephone = dt.Rows[i]["Telephone"].ToString(),
                    Duty = dt.Rows[i]["Duty"].ToString(),
                    Username = dt.Rows[i]["Username"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    Desired = Parse(dt.Rows[i]["Desired"].ToString())
                };

                _clients.Add(client);
            }
        }

    }


}
