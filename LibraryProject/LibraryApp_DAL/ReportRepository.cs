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
    public class ReportRepository : IReportRepository
    {
        private readonly DConnectivity _connection;
        private readonly List<Report> _reports = new List<Report>();

        public ReportRepository(DConnectivity connection)
        {
            this._connection = connection;
        }

        public List<Report> GetReports()
        {
            var command = _connection.DbCommand(
                "SELECT Client.FirstName, Book.Title, LibraryFile.BorrowDate, LibraryFile.ReturnDate, Branch.Name from Client " +
                "INNER JOIN LibraryFile ON Client.ID = LibraryFile.ClientID " +
                "INNER JOIN BranchXBook ON  LibraryFile.BranchXBookID = BranchXBook.ID " +
                "INNER JOIN Branch ON BranchXBook.LibraryID = Branch.ID " +
                "INNER JOIN Book ON BranchXBook.BookID = Book.ID ");

            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            ListOfReports(dt);
            reader.Close();
            return _reports;


        }

        private void ListOfReports(DataTable dt)
        {
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var report = new Report
                {
                    ClientName = dt.Rows[i]["FirstName"].ToString(),
                    BookName = dt.Rows[i]["Title"].ToString(),
                    BorrowDate = DateTime.Parse(dt.Rows[i]["BorrowDate"].ToString()),
                    ReturnDate = DateTime.Parse(dt.Rows[i]["ReturnDate"].ToString()),

                };

                _reports.Add(report);
            }
        }
    }
}
