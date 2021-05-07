using System;
using System.Collections.Generic;
using System.Data;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;

namespace LibraryApp_DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly DConnectivity _connection;
        private List<Book> _listOfBooks = new List<Book>();

        public BookRepository(DConnectivity connection)
        {
            this._connection = connection;
        }

        private void ListOfBooks(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var book = new Book
                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    UniqueCode = dt.Rows[i]["UniqueCode"].ToString(),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Author = dt.Rows[i]["Author"].ToString(),
                    Editure = dt.Rows[i]["Editure"].ToString(),
                    Genre =dt.Rows[i]["Genre"].ToString()
                };

                _listOfBooks.Add(book);
            }
        }

        public List<Book> GetBooks()
        {
            var command = _connection.DbCommand("SELECT * FROM Book");
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfBooks(dt);
            return _listOfBooks;
        }

        public bool DeleteBook(Book book)
        {
            var command = _connection.DbCommand("DELETE FROM Book WHERE ID=@ID");
            command.Parameters.AddWithValue("@ID", book.ID);
            return command.ExecuteNonQuery() == 1;
        }

        public Book GetBookById(int id)
        {
            var book = new Book();
            var command = _connection.DbCommand("SELECT Count(1) FROM Book WHERE ID=@ID");
            command.Parameters.AddWithValue("@ID", id);
            return book;
        }

        public bool UpdateBook(Book book)
        {
            var command = _connection.DbCommand("UPDATE Book SET Title=@title, UniqueCode=@uniqueCode, Author=@authors" +
                ", Editure=@editure, Genre=@genre WHERE ID=@ID"); 

            command.Parameters.AddWithValue("@ID",book.ID);
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@uniqueCode", book.UniqueCode);
            command.Parameters.AddWithValue("@authors", book.Author);
            command.Parameters.AddWithValue("@editure", book.Editure);
            command.Parameters.AddWithValue("@genre", book.Genre);

            return command.ExecuteNonQuery() == 1;
        }

        public bool AddBook(Book book)
        {
            _listOfBooks = GetBooks();
            var command = _connection.DbCommand("SELECT * FROM Book WHERE Title=@title AND UniqueCode=@uniqueCode AND Author=@authors AND Editure=@editure");
            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@uniqueCode", book.UniqueCode);
            command.Parameters.AddWithValue("@authors", book.Author);
            command.Parameters.AddWithValue("@editure", book.Editure);
            var result = command.ExecuteScalar();
            if (result == null)
            {

                command = _connection.DbCommand("INSERT INTO Book(Title, UniqueCode, Author, Editure, Genre)" +
                                                " VALUES (@title, @uniqueCode, @authors, @editure, @genre)");

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@uniqueCode", book.UniqueCode);
                command.Parameters.AddWithValue("@authors", book.Author);
                command.Parameters.AddWithValue("@editure", book.Editure);
                command.Parameters.AddWithValue("@genre", book.Genre);
            }
            else
            {
                return false;
            }

            return command.ExecuteNonQuery() == 1;
        }
    }
}
