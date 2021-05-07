﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp.DataModel.Enums;
using static System.Int16;

namespace LibraryApp_DAL
{
    public class LibraryFileRepository: ILibraryFileRepository
    {
        private readonly DConnectivity _connection;
        private readonly List<LibraryFile> _libraryFiles = new List<LibraryFile>();
        private readonly BranchXBookRepository inventoryRepository;
        private readonly List<Book> _books = new List<Book>();
        private List<Branch> _branchesOfBook = new List<Branch>();
       

        public LibraryFileRepository(DConnectivity connection)
        {
            this._connection = connection;
            inventoryRepository = new BranchXBookRepository(connection);

        }
        public bool AddLibraryFile(Client client, Book book, Branch branch)
        {
            var command =
                _connection.DbCommand("SELECT ID FROM BranchXBook WHERE LibraryId=@branchId AND BookId=@bookId");
            command.Parameters.AddWithValue("@branchId", branch.ID);
            command.Parameters.AddWithValue("@bookId", book.ID);
            var reader = command.ExecuteReader();
            reader.Read();
            int inventoryId = reader.GetInt32(0);
            command.Connection.Close();

            command = _connection.DbCommand(
                "INSERT INTO LibraryFile(BranchXBookID, ClientID, BorrowDate, DueDate)" +
                " VALUES (@inventoryId, @clientId, @borrowDate, @dueDate)");

            command.Parameters.AddWithValue("@inventoryId", inventoryId);
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@borrowDate", DateTime.Now);
            command.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(7));

            inventoryRepository.BorrowBookFromBranch(book, branch.Name);

            return command.ExecuteNonQuery() == 1;
        }

        public bool RenewDueDate(Client client, Book book)
        {
            var inventoryId = 0;
           
            
            var command = _connection.DbCommand(
                "SELECT BranchXBook.ID FROM BranchXBook INNER JOIN Book ON Book.ID = BranchXBook.BookID INNER JOIN LibraryFile ON " +
                "LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID WHERE Client.ID=@clientId AND Book.ID=@bookId");
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@bookId", book.ID);

            var reader = command.ExecuteReader();
            reader.Read();
            inventoryId = reader.GetInt32(0);
            reader.Close();
            command = _connection.DbCommand(
                "SELECT DueDate, BorrowDate From LibraryFile WHERE BranchXBookID=@inventoryId AND ClientID=@clientId");

            command.Parameters.AddWithValue("@inventoryId", inventoryId);
            command.Parameters.AddWithValue("@clientId", client.ID);
            reader = command.ExecuteReader();
            reader.Read();
            var dueD= reader.GetDateTime(0);
            var borrowD = reader.GetDateTime(1);

            if (DateTime.Compare(DateTime.Now, dueD) < 0 && (DateTime.Compare(dueD.AddDays(7), borrowD.AddDays(21)) < 0 || 
                                                             (DateTime.Compare(dueD.AddDays(7), borrowD.AddDays(21)) == 0)))
            {
                dueD = dueD.AddDays(7);
            }
            else
                return false;

            command = _connection.DbCommand(
                "UPDATE LibraryFile SET DueDate=@dueD WHERE ClientId=@clientId AND BranchXBookID=@inventoryId");
            command.Parameters.AddWithValue("@dueD", dueD);
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@inventoryId", inventoryId);
            reader.Close();
            return command.ExecuteNonQuery() == 1;
        }

        public bool ReturnBook(Client client, Book book)
        {
            int inventoryId = 0;

            var command = _connection.DbCommand(
                "SELECT BranchXBook.ID FROM BranchXBook INNER JOIN Book ON Book.ID = BranchXBook.BookID INNER JOIN LibraryFile ON " +
                "LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID WHERE Client.ID=@clientId AND Book.ID=@bookId");
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@bookId", book.ID);
            var reader = command.ExecuteReader();
            reader.Read();
            inventoryId = reader.GetInt32(0);
            reader.Close();
            //command = _connection.DbCommand(
            //    "SELECT DueDate, BorrowDate From LibraryFile WHERE BranchXBookID=@inventoryId AND ClientID=@clientId");

            //command.Parameters.AddWithValue("@inventoryId", inventoryId);
            //command.Parameters.AddWithValue("@clientId", client.ID);
            //reader = command.ExecuteReader();
            //reader.Read();
            //DateTime dueD = reader.GetDateTime(0);
            //if (DateTime.Compare(DateTime.Now, dueD) < 0)
            //{
            //    command = _connection.DbCommand("UPDATE Client SET Desired=@desired WHERE ID=@clientId");
            //    command.Parameters.AddWithValue("@desired", false);
            //    command.Parameters.AddWithValue("@clientId", client.ID);
            //}

            command = _connection.DbCommand(
                "SELECT Branch.Name FROM Branch INNER JOIN BranchXBook ON Branch.ID = BranchXBook.LibraryID INNER JOIN " +
                "LibraryFile ON LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID" +
                " WHERE Client.ID =@clientId AND BookID = @bookId");
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@bookId", book.ID);
            reader = command.ExecuteReader();
            reader.Read();
            var branchName = reader.GetString(0);
            reader.Close();

            if (branchName != null)
            {
                inventoryRepository.ReturnBookFromBranch(book, branchName);

                command = _connection.DbCommand(
                    "UPDATE LibraryFile SET ReturnDate=@returnDate WHERE ClientId=@clientId AND BranchXBookID=@inventoryId");
                command.Parameters.AddWithValue("@returnDate", DateTime.Now);
                command.Parameters.AddWithValue("@clientId", client.ID);
                command.Parameters.AddWithValue("@inventoryId", inventoryId);

                return command.ExecuteNonQuery() != 0;
            }

            return false;
        }

        public bool IsReturned(Client client, Book book)
        {
            int inventoryId = 0;

            var command = _connection.DbCommand(
                "SELECT BranchXBook.ID FROM BranchXBook INNER JOIN Book ON Book.ID = BranchXBook.BookID INNER JOIN LibraryFile ON " +
                "LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID WHERE Client.ID=@clientId AND Book.ID=@bookId");
            command.Parameters.AddWithValue("@clientId", client.ID);
            command.Parameters.AddWithValue("@bookId", book.ID);
            var reader = command.ExecuteReader();
            reader.Read();
            inventoryId = reader.GetInt32(0);
            reader.Close();
            
            command = _connection.DbCommand(
                "SELECT ReturnDate FROM LibraryFile WHERE BranchXBookID=@inventoryId AND ClientID=@clientId");

            command.Parameters.AddWithValue("@inventoryId", inventoryId);
            command.Parameters.AddWithValue("@clientId", client.ID);
            reader = command.ExecuteReader();
            reader.Read();
            var returnDate = reader[0];
            var dt=(returnDate == DBNull.Value) ? (DateTime?) null : Convert.ToDateTime(returnDate);
            return dt != null;
        }

        public List<Book> GetBorrowedBooks(Client client)
        {
            var command =
                _connection.DbCommand("SELECT * FROM Book INNER JOIN BranchXBook ON BranchXBook.BookID = Book.ID INNER JOIN" +
                                      " LibraryFile ON LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID " +
                                      "WHERE Client.ID = @clientId AND ReturnDate IS NULL");
            command.Parameters.AddWithValue("@clientId", client.ID);

            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfBooks(dt);
            reader.Close();
            return _books;
        }

        public List<Book> GetBookHistory(Client client)
        {
            var command =
                _connection.DbCommand("SELECT * FROM Book INNER JOIN BranchXBook ON BranchXBook.BookID = Book.ID INNER JOIN" +
                                      " LibraryFile ON LibraryFile.BranchXBookID = BranchXBook.ID INNER JOIN Client ON LibraryFile.ClientID = Client.ID " +
                                      "WHERE Client.ID = @clientId AND ReturnDate <> 0");
            command.Parameters.AddWithValue("@clientId", client.ID);

            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfBooks(dt);
            reader.Close();
            return _books;
        }

        private List<Book> ListOfBooks(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var book = new Book
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    UniqueCode = dt.Rows[i]["UniqueCode"].ToString(),
                    Title = dt.Rows[i]["Title"].ToString(),
                    Author = dt.Rows[i]["Author"].ToString(),
                    Editure = dt.Rows[i]["Editure"].ToString(),
                    Genre =  dt.Rows[i]["Genre"].ToString()
                };
                _books.Add(book);
            }
            return _books;
        }


        public List<LibraryFile> GetLibraryFiles()
        {
            var command = _connection.DbCommand("SELECT * FROM Book");
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfFiles(dt);
            return _libraryFiles;
        }

        private List<LibraryFile> ListOfFiles(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var libraryFile = new LibraryFile
                {
                    ID = int.Parse(dt.Rows[i]["ID"].ToString()),
                    InventoryId = Parse((string) dt.Rows[i]["Inventory"]),
                    ClientId = Parse(dt.Rows[i]["ClientId"].ToString()),
                    BorrowDate = DateTime.Parse(dt.Rows[i]["BorrowDate"].ToString()),
                    DueDate = DateTime.Parse(dt.Rows[i]["DueDate"].ToString()),
                    ReturnDate = DateTime.Parse(dt.Rows[i]["ReturnDate"].ToString())
                };
                _libraryFiles.Add(libraryFile);
            }

            return _libraryFiles;
        }
    }
}
