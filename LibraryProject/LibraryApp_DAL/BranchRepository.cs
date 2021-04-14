using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using System.Data;

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

        public bool DeleteBranch(Branch branch)
        {
            var command = _connection.dbCommand("SELECT * FROM BranchXBook INNER JOIN Branch ON BranchXBook.LibraryID=Branch.ID" +
                " AND Branch.ID=@ID");
            command.Parameters.AddWithValue("@ID", branch.ID);
            Object result = command.ExecuteScalar();
            if (result!=null)
            {
                return false;
            }
            else
            {
                command = _connection.dbCommand("DELETE FROM Branch WHERE ID=@ID");
                command.Parameters.AddWithValue("@ID", branch.ID);

                return command.ExecuteNonQuery() > 0;
            }
            
        }

        public List<Branch> GetBranches()
        {
            var command = _connection.dbCommand("SELECT * FROM Branch");
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfBranches(dt);
            return _listOfBranches;
        }

        public List<Branch> ListOfBranches(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var branch = new Branch
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString()
                };
                _listOfBranches.Add(branch);
            }

            return _listOfBranches;
        }

        public bool UpdateBranch(Branch branch)
        {
            var command = _connection.dbCommand("UPDATE Branch SET Name=@name, Address=@address" +
                                                " WHERE ID=@ID");

            command.Parameters.AddWithValue("@ID", branch.ID);
            command.Parameters.AddWithValue("@name", branch.Name);
            command.Parameters.AddWithValue("@address", branch.Address);

            return command.ExecuteNonQuery() == 1;
        }
    }

   
}
