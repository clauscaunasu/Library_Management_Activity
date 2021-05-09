using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BusinessLogic.Abstractions;
using LibraryApp.DataModel;

namespace LibraryApp_DAL
{
    public class MoreInformationRepository : IMoreInformationRepository
    {
        private readonly DConnectivity _connection;
        private readonly List<MoreInformation> _info = new List<MoreInformation>();

        public MoreInformationRepository(DConnectivity connection)
        {
            this._connection = connection;
        }

        public List<MoreInformation> GetMoreInformation(Book book)
        {
            var command = _connection.DbCommand(
                "SELECT Branch.Name, BranchXBook.BookQuantity FROM Branch " +
                "INNER JOIN BranchXBook ON BranchXBook.LibraryID = Branch.ID " +
                "INNER JOIN Book ON BranchXBook.BookID = Book.ID " +
                "WHERE Book.ID=@bookId ");
            command.Parameters.AddWithValue("@bookId", book.ID);

            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfInfo(dt);
            reader.Close();
            return _info;


        }

        private void ListOfInfo(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var newInfo = new MoreInformation()
                {
                    BranchName = dt.Rows[i]["Name"].ToString(),
                    QuantityInBranch = Int32.Parse(dt.Rows[i]["BookQuantity"].ToString()),

                };

                _info.Add(newInfo);
            }
        }
    }
}