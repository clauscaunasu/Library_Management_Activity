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
    public class BranchXBookRepository : IBranchXBookRepository
    {
        private readonly DConectivity _connection;
        private List<Branch> _listOfBranches = new List<Branch>();
        private List<Book> _listOfBooks = new List<Book>();
        private readonly BranchRepository _branchRepository;
        private readonly BookRepository _bookRepository;


        public BranchXBookRepository(DConectivity connection)
        {
            this._connection = connection;
            _branchRepository = new BranchRepository(connection);
            _bookRepository = new BookRepository(connection);
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

            var command = _connection.dbCommand("SELECT * FROM Book WHERE Title=@title AND UniqueCode=@isbn AND Author=@author AND Editure=@editure");
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@isbn", book.UniqueCode);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@editure", book.Editure);
            Object result = command.ExecuteScalar();
            if(result==null)
            {
                _bookRepository.AddBook(book);
                _listOfBooks = _bookRepository.GetBooks();
                book.ID = _listOfBooks[_listOfBooks.Count - 1].ID;
            }
            var command2 = _connection.dbCommand("SELECT * FROM BranchXBook WHERE LibraryID=@branchId AND BookId=@bookId");
            command2.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command2.Parameters.AddWithValue("@bookId", book.ID);
            Object result2 = command2.ExecuteScalar();
            if (result2==null)
            {
                command = _connection.dbCommand("INSERT INTO BranchXBook(BookId, LibraryID, BookQuantity)" +
                                          " VALUES (@bookId, @branchId, @quantity)");

                command.Parameters.AddWithValue("@bookId", book.ID);
                command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
                command.Parameters.AddWithValue("@quantity", quantity);
            }
            else
            {
                command = _connection.dbCommand("UPDATE BranchXBook SET BookQuantity=@quantity WHERE BookId=@bookId AND LibraryID=@branchId");
                command.Parameters.AddWithValue("@bookId", book.ID);
                command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
                command.Parameters.AddWithValue("@quantity", quantity);

            }

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
            var command = _connection.dbCommand("DELETE FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");

            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);

            return command.ExecuteNonQuery() == 1;
        }

        public int GetNoCopiesFromBranch(Branch branch, Book book)
        {
            var command = _connection.dbCommand("SELECT BookQuantity FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", branch.ID);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            int copies = dr.GetInt32(0);
            dr.Close();
            command.Connection.Close();
            return copies;

        }

        public bool BorrowBookFromBranch(Book book, string branchName)
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
            var currentQuantity = this.GetNoCopiesFromBranch(_branchToAdd, book);

            var command = _connection.dbCommand("UPDATE BranchXBook SET BookQuantity=@quantity - 1 WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command.Parameters.AddWithValue("@quantity", currentQuantity);

            return command.ExecuteNonQuery() == 1;
        }

        public bool RenewBookFromBranch(Book book, string branchName, Client client)
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

            var cmnd = _connection.dbCommand("SELECT ID FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");
            cmnd.Parameters.AddWithValue("@bookId", book.ID);
            cmnd.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            SqlDataReader dr = cmnd.ExecuteReader();
            dr.Read();
            int idInventory = dr.GetInt32(0);
            dr.Close();
            cmnd.Connection.Close();

            var command = _connection.dbCommand("UPDATE LibraryFile SET ReturnDate=@timenow WHERE InventoryId=@inventoryid AND ClientId=@clientid");
            command.Parameters.AddWithValue("@inventoryid", idInventory);
            command.Parameters.AddWithValue("@clientid", client.ID);
            command.Parameters.AddWithValue("@timenow", DateTime.Now.Day + 7);

            return command.ExecuteNonQuery() == 1;

        }

        public bool ReturnBookFromBranch(Book book, string branchName)
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

            var currentQuantity = this.GetNoCopiesFromBranch(_branchToAdd, book);
            var command = _connection.dbCommand("UPDATE BranchXBook SET BookQuantity=@quantity + 1 WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command.Parameters.AddWithValue("@quantity", currentQuantity);

            return command.ExecuteNonQuery() == 1;
        }
    }
}
