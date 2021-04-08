using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp_DAL
{
    class BookRepository : IBookRepository
    {
        private readonly DConectivity _connection;
        private readonly List<Book> _listOfBooks = new List<Book>();
        public BookRepository(DConectivity connection)
        {
            this._connection = connection;
        }
        public bool AddBookInBranch(Book book, string branchName, int copies)
        {
            var branchID = 0;
            var bookID = 0;


            var command = _connection.dbCommand ("INSERT INTO Book(Title, UniqueCode, Author, Editure)" +
                                      " VALUES (@title, @uniqueCode, @authors, @editure)");

            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@uniqueCode", book.UniqueCode); 
            command.Parameters.AddWithValue("@authors", book.Author);
            command.Parameters.AddWithValue("@editure", book.Editure);

            if (command.ExecuteNonQuery() == 1)
            {
                command.CommandText = "SELECT ID FROM Book WHERE UniqueCode = @uniqueCode1";
                command.Parameters.AddWithValue("@uniqueCode1", book.UniqueCode);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bookID = reader.GetInt32(0);
                }

                reader.Close();

                command.CommandText = "select ID from Branch where Name = @branchName1";
                command.Parameters.AddWithValue("@branchName1", branchName);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    branchID = reader.GetInt32(0);
                }

                reader.Close();


                if (branchID != 0 && bookID != 0)
                {
                    command.CommandText = "INSERT INTO BranchXBook(LibraryID, BookId, BookQuantity)" +
                                              " VALUES (@libraryID, @bookId, @bookQuantity)";
                    command.Parameters.AddWithValue("@libraryId", branchID);
                    command.Parameters.AddWithValue("@bookId", bookID);
                    command.Parameters.AddWithValue("@bookQuantity", copies);
                }
            }


            return command.ExecuteNonQuery() == 1;
        }
        

        public List<Book> ShowListOfBooks(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var book = new Book();
                book.ID = Int32.Parse(dt.Rows[i]["ID"].ToString()); 
                book.UniqueCode = dt.Rows[i]["UniqueCode"].ToString(); 
                book.Title = dt.Rows[i]["Title"].ToString(); 
                book.Author = dt.Rows[i]["Author"].ToString(); 
                book.Editure = dt.Rows[i]["Editure"].ToString();  
                _listOfBooks.Add(book);
            }

            return _listOfBooks;
        }

        public Book GetBookById(int id)
        {
            var book = new Book();
            var command = _connection.dbCommand("SELECT Count(1) FROM Book WHERE ID=@ID");
            command.Parameters.AddWithValue("@ID", id);
            return book;
        }

    }
}
