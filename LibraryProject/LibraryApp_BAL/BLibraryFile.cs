using System;

namespace LibraryApp_BAL
{
    class BLibraryFile
    {
        public int ID { get; set; }
        public int InventoryId { get; set; }
        public int ClientId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
