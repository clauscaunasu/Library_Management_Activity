using System.Collections.Generic;
using System.Collections.ObjectModel;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;
using LibraryApp_DAL;



// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public partial class Service : IService
{

    private IUserRepository GetUserRepository()
    {
        return new UserRepository(new DConnectivity());
    }

    
    private IBookRepository GetBookRepository()
    {
        return new BookRepository(new DConnectivity());
    }

    private IBranchRepository GetBranchRepository()
    {
        return new BranchRepository(new DConnectivity());
    }

    private IBranchXBookRepository GetBranchXBookRepository()
    {
        return new BranchXBookRepository(new DConnectivity());
    }

    /*
        public List<string> GetBranches()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];


            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(string.Empty, connection);
                command.Connection.Open();
                command.CommandText = "select count(*) from Branch";
                var result = command.ExecuteScalar();

                return new List<string>();
            }
        }

        public bool Register(string firstName, string lastName, string address, string telephone, string username, string password)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(string.Empty, connection);
                command.Connection.Open();
                command.CommandText = "INSERT INTO Client(FirstName, LastName, Address, Telephone, Username, Password)" +
                                      " VALUES (@firstName, @lastName, @address, @telephone, @username, @password)";

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@telephone", telephone);
                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@firstName", firstName);


                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool LogIn(string username, string password)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(string.Empty, connection);
                command.Connection.Open();
                command.CommandText = "SELECT COUNT(1) FROM Client WHERE Username = @Username " +
                                       "AND Password = @Password";
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                var result = (int)command.ExecuteScalar();
                return result == 1;
            }
        }

        public List<string> BranchListLoader()
        {
            var branchesNames = new List<string>();
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(string.Empty, connection);
                command.Connection.Open();
                command.CommandText = "SELECT * FROM Branch";
                command.ExecuteNonQuery();
                var da = new SqlDataAdapter(command);
                var dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    branchesNames.Add(dr["Name"].ToString());
                }
            }

            return branchesNames;
        }

       /* public bool AddBook(string title, string isbn, string authors, string editure, string branch, int copies)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var branchID = 0;
            var bookID = 0;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(string.Empty, connection);
                command.Connection.Open();
                command.CommandText = "INSERT INTO Book(Title, UniqueCode, Author, Editure)" +
                                      " VALUES (@title, @uniqueCode, @authors, @editure)";

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@uniqueCode", isbn);
                command.Parameters.AddWithValue("@authors", authors);
                command.Parameters.AddWithValue("@editure", editure);

                if (command.ExecuteNonQuery() == 1)
                {
                    command.CommandText = "SELECT ID FROM Book WHERE UniqueCode = @uniqueCode1";
                    command.Parameters.AddWithValue("@uniqueCode1", isbn);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        bookID = reader.GetInt32(0);
                    }

                    reader.Close();

                    command.CommandText = "select ID from Branch where Name = @branchName1";
                    command.Parameters.AddWithValue("@branchName1", branch);
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
        }
        */

    public bool EditMember(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.EditMember(client);
    }

    public bool DeleteMember(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.DeleteMember(client);
    }


    public bool MemberRegister(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.Add(client);
    }

    public Client MemberLogin(Client client)
    {
        var userRepository = GetUserRepository();
        return userRepository.GetUserByNameAndPassword(client.Username, client.Password);

    }

    public List<Client> ClientList()
    {
        var userRepository = GetUserRepository();
        return userRepository.GetClients();
    }
    public List<Book> BooksList()
    {
        var bookRepository = GetBookRepository();
        return bookRepository.GetBooks();
    }

    public bool EditBook(Book book)
    {
        var bookRepository = GetBookRepository();
        return bookRepository.UpdateBook(book);
    }

    public bool AddBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.AddBranch(branch);
    }

    public List<Branch> ViewBranches()
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.GetBranches();
    }

    public bool EditBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.UpdateBranch(branch);
    }

    public bool DeleteBranch(Branch branch)
    {
        var branchRepository = GetBranchRepository();
        return branchRepository.DeleteBranch(branch);
    }

    public bool AddBook(Book book)
    {
        var bookRepository = GetBookRepository();
        return bookRepository.AddBook(book);
    }

    public Client GetClient(Client client)
    {
        var clientRep = GetUserRepository();
        return clientRep.GetClient(client);
    }

    public bool AddBookInBranch(Book book, string branchName, int quantity)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.AddBookInBranch(book, branchName, quantity);
    }

    public bool DeleteBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.DeleteBookFromBranch(book, branchName);
    }

    public int GetNoCopiesFromBranch(Branch branch, Book book)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.GetNoCopiesFromBranch(branch, book);
    }

    public bool BorrowBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.BorrowBookFromBranch(book, branchName);
    }

    public bool RenewBookFromBranch(Book book, string branchName, Client client)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.RenewBookFromBranch(book, branchName, client);
    }

    public bool ReturnBookFromBranch(Book book, string branchName)
    {
        var branchXBookRep = GetBranchXBookRepository();
        return branchXBookRep.ReturnBookFromBranch(book, branchName);
    }

}
