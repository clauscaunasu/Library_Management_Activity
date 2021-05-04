namespace LibraryApp.DataModel
{
    public class Inventory
    {
        public int ID { get; set; }
        public int LibraryID { get; set; }
        public int BookId { get; set; }
        public int BookQuantity { get; set; }
    }
}
