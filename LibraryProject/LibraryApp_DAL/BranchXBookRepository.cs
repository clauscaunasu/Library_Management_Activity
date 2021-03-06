using System;
using System.Collections.Generic;
using System.Data;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;

namespace LibraryApp_DAL
{
    public class BranchXBookRepository : IBranchXBookRepository
    {
        private readonly DConnectivity _connection;
        private List<Branch> _listOfBranches = new List<Branch>();
        private List<Book> _listOfBooks = new List<Book>();
        private readonly BranchRepository _branchRepository;
        private readonly BookRepository _bookRepository;


        public BranchXBookRepository(DConnectivity connection)
        {
            this._connection = connection;
            _branchRepository = new BranchRepository(connection);
            _bookRepository = new BookRepository(connection);
        }

        public List<Book> GetBooksFromBranch(string branchName)
        {
            var bookList = new List<Book>();
            var command = _connection.DbCommand("SELECT * FROM Book INNER JOIN BranchXBook ON BranchXBook.BookID = Book.ID INNER JOIN Branch ON BranchXBook.LibraryID = Branch.ID WHERE Branch.Name = @BranchName");
            command.Parameters.AddWithValue("@BranchName", branchName);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var book = new Book()
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    UniqueCode = dt.Rows[i]["UniqueCode"].ToString(),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Author = dt.Rows[i]["Author"].ToString(),
                    Editure = dt.Rows[i]["Editure"].ToString(),
                    Genre = dt.Rows[i]["Genre"].ToString()
                };

                bookList.Add(book);
            }
            reader.Close();
            return bookList;
        }
        
        public bool AddBookInBranch(Book book, string branchName, int quantity)
        {
            var _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();
            foreach(var currentBranch in _listOfBranches)
            {
                if(branchName==currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }

            var command = _connection.DbCommand("SELECT * FROM Book WHERE Title=@title AND UniqueCode=@isbn AND Author=@author AND Editure=@editure");
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@isbn", book.UniqueCode);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@editure", book.Editure);
            var result = command.ExecuteScalar();
            if(result==null)
            {
                _bookRepository.AddBook(book);
                _listOfBooks = _bookRepository.GetBooks();
                book.ID = _listOfBooks[_listOfBooks.Count - 1].ID;
            }
            var command2 = _connection.DbCommand("SELECT * FROM BranchXBook WHERE LibraryID=@branchId AND BookId=@bookId");
            command2.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command2.Parameters.AddWithValue("@bookId", book.ID);
            var result2 = command2.ExecuteScalar();
            if (result2==null)
            {
                command = _connection.DbCommand("INSERT INTO BranchXBook(BookId, LibraryID, BookQuantity)" +
                                                " VALUES (@bookId, @branchId, @quantity)");

                command.Parameters.AddWithValue("@bookId", book.ID);
                command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
                command.Parameters.AddWithValue("@quantity", quantity);
            }
            else
            {
                command = _connection.DbCommand("UPDATE BranchXBook SET BookQuantity=@quantity WHERE BookId=@bookId AND LibraryID=@branchId");
                command.Parameters.AddWithValue("@bookId", book.ID);
                command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
                command.Parameters.AddWithValue("@quantity", quantity);

            }

            return command.ExecuteNonQuery() == 1;

        }

        public bool DeleteBookFromBranch(Book book, string branchName)
        {
            var _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();
            foreach (var currentBranch in _listOfBranches)
            {
                if (branchName == currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }
            var command = _connection.DbCommand("DELETE FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");

            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);

            return command.ExecuteNonQuery() == 1;
        }

        public int GetNoCopiesFromBranch(Branch branch, Book book)
        {
            var copies = 0;
            var command = _connection.DbCommand("SELECT BookQuantity FROM BranchXBook WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", branch.ID);
            var result = command.ExecuteScalar();
            
            if (result!=null)
            {
                var dr = command.ExecuteReader();
                dr.Read();
                copies = dr.GetInt32(0);
                dr.Close();
                command.Connection.Close();
            }
           
            return copies;

        }

        public bool BorrowBookFromBranch(Book book, string branchName)
        {
            var _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();

            foreach (var currentBranch in _listOfBranches)
            {
                if (branchName == currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }
            var currentQuantity = this.GetNoCopiesFromBranch(_branchToAdd, book);

            var command = _connection.DbCommand("UPDATE BranchXBook SET BookQuantity=@quantity - 1 WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command.Parameters.AddWithValue("@quantity", currentQuantity);

            

            return command.ExecuteNonQuery() == 1;
        }

        public List<Branch> BranchesForBook(Book book)
        {
            List<Branch> _branchesForBook = new List<Branch>();
            var command = _connection.DbCommand(
                "SELECT * FROM Branch INNER JOIN BranchXBook ON BranchXBook.LibraryID=Branch.ID INNER JOIN " +
                "Book ON BranchXBook.BookId=Book.ID WHERE Book.Title=@title");
            command.Parameters.AddWithValue("@title", book.Title);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var branch = new Branch()
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),

                };

                _branchesForBook.Add(branch);
            }
            reader.Close();
            return _branchesForBook;

        }

        public int GetQuantityOfBook(Book book)
        {
            var command = _connection.DbCommand(
                "SELECT SUM(BookQuantity) FROM BranchXBook INNER JOIN Branch ON BranchXBook.LibraryID=Branch.ID INNER JOIN " +
                "Book ON BranchXBook.BookId=Book.ID WHERE Book.Title=@title");
            command.Parameters.AddWithValue("@title", book.Title);
            var reader = command.ExecuteReader();
            reader.Read();
            int quantity = reader.GetInt16(0);
            reader.Close();
            command.Connection.Close();
            return quantity;

        }

        public bool ReturnBookFromBranch(Book book, string branchName)
        {
            var _branchToAdd = new Branch();
            _listOfBranches = _branchRepository.GetBranches();

            foreach (var currentBranch in _listOfBranches)
            {
                if (branchName == currentBranch.Name)
                {
                    _branchToAdd = currentBranch;
                }
            }

            var currentQuantity = this.GetNoCopiesFromBranch(_branchToAdd, book);
            var command = _connection.DbCommand("UPDATE BranchXBook SET BookQuantity=@quantity + 1 WHERE BookId=@bookId AND LibraryID=@branchId");
            command.Parameters.AddWithValue("@bookId", book.ID);
            command.Parameters.AddWithValue("@branchId", _branchToAdd.ID);
            command.Parameters.AddWithValue("@quantity", currentQuantity);

            return command.ExecuteNonQuery() == 1;
        }
    }
}
