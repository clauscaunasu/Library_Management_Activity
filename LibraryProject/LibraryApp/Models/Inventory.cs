using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Inventory
    {
        public int ID { get; set; }
        public int LibraryID { get; set; }
        public int BookId { get; set; }
        public int BookQuantity { get; set; }
    }
}
