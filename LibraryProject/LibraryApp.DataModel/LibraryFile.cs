﻿using System;

namespace LibraryApp.DataModel
{
    public class LibraryFile
    {
        public int ID { get; set; }
        public int InventoryId { get; set; }
        public int ClientId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
