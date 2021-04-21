using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp_DAL
{
    public class BranchXBookRepository : IBranchXBookRepository
    {
        private readonly DConectivity _connection;
        private List<Branch> _listOfBranches = new List<Branch>();
        private readonly BranchRepository _branchRepository;


        public BranchXBookRepository(DConectivity connection)
        {
            this._connection = connection;
            _branchRepository = new BranchRepository(connection);
        }
        public bool AddBookInBranch(Book book, string branchName, int quantity)
        {
            Branch _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();
            foreach(var currentBranch in _listOfBranches)
            {
                if(branchName==currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }
            var command = _connection.dbCommand("INSERT INTO BranchXBook(BookId, LibraryID, BookQuantity)" +
                                      " VALUES (@bookId, @branchId, @quantity)");

            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command.Parameters.AddWithValue("@quantity", quantity);

            return command.ExecuteNonQuery() == 1;

        }

        public bool DeleteBookFromBranch(Book book, string branchName)
        {
            Branch _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();
            foreach (var currentBranch in _listOfBranches)
            {
                if (branchName == currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }
            var command = _connection.dbCommand("DELETE * FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");

            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);

            return command.ExecuteNonQuery() == 1;
        }
    }
}
