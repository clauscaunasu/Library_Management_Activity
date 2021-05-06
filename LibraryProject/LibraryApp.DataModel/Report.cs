using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.DataModel
{
    public class Report
    {
        public string ClientName { get; set; }
        public string BookName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public  string BranchName { get; set; }
    }
}
