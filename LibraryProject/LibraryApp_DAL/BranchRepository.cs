using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp_DAL
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DConectivity _connection;
        private readonly List<Branch> _listOfBranches = new List<Branch>();

        public BranchRepository(DConectivity connection)
        {
            this._connection = connection;
        }

        public bool AddBranch(Branch branch)
        {
            var command = _connection.dbCommand("INSERT INTO Branch(Name, Address)" +
                                     " VALUES (@name, @address)");
            command.Parameters.AddWithValue("@name", branch.Name);
            command.Parameters.AddWithValue("@address", branch.Address);

            return command.ExecuteNonQuery() == 1;
        }
    }
}
