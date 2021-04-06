using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bal = LibraryApp_BAL;


namespace LibraryApp_DAL
{
    public class DMember
    {
        DConectivity connect = new DConectivity();
        private SqlCommand command = new SqlCommand();
        private List<bal.BClient> clients = new List<bal.BClient>();

        public int register(bal.BClient client)
        {
            command = connect.dbCommand(
                "INSERT INTO Client(FirstName, LastName, Address, Telephone, Username, Password)" +
                " VALUES (@firstName, @lastName, @address, @telephone, @username, @password)");

            command.Parameters.AddWithValue("@username", client.Username);
            command.Parameters.AddWithValue("@password", client.Password);
            command.Parameters.AddWithValue("@telephone", client.Telephone);
            command.Parameters.AddWithValue("@address", client.Address);
            command.Parameters.AddWithValue("@lastName", client.LastName);
            command.Parameters.AddWithValue("@firstName", client.FirstName);


            return command.ExecuteNonQuery();
        }

    }
}
