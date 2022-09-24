using System.Net.NetworkInformation;

namespace BooksManagement_Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int AvailableCopies { get; set; }
        public bool IsDeleted { get; set; }

    }
}