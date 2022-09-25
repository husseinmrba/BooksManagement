using BooksManagement_Domain;
namespace BooksManagement_DataAccess.DatabaseControl
{
    public class BookControl
    {
        public static void ModifyBook()
        {
            Console.Write("Please enter the book number: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int bookId);
            using (var context = new BooksMDBContext())
            {
                var book = context.Books
                        .FirstOrDefault(b => b.BookId == bookId);

                Console.Write("Please enter the new book title:");
                string newTitle = Console.ReadLine();
                Console.Write("Please enter the new book price:");
                string strnewPrice = Console.ReadLine();
                Int32.TryParse(strnewPrice, out int newPrice);
                book.Title = newTitle;
                book.Price = newPrice;
                context.SaveChanges();


            }
            
        }
        public static void DeleteBook()
        {
            Console.Write("Please enter the book title: ");
            string bookTitle = Console.ReadLine();
            using (var context = new BooksMDBContext())
            {
                var book = context.Books
                            .FirstOrDefault(b => b.Title == bookTitle);
                Console.WriteLine("Are you sure you want to delete the book? [y/n]");
                string res = Console.ReadLine();
                if (res.Contains("y") || res.Contains("Y"))
                {
                    book.IsDeleted = true;
                    context.SaveChanges();
                    Console.WriteLine("The book has been deleted");
                }
                else
                {
                    Console.WriteLine("The book has not been deleted");
                }

            }
        }
        public static void PrintInfoBook(Book book)
        {
            if (book != null)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Book number: {book.BookId}");
                Console.WriteLine($"Book title: {book.Title}");
                Console.WriteLine($"Book price: {book.Price}");
                Console.WriteLine($"Copies of the book are available: {book.AvailableCopies}");
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Book is not found");
            }
        }
        public static Book GetBookInfo()
        {
            using (var context = new BooksMDBContext())
            {
                Console.Write("Please enter the book number: ");
                string input = Console.ReadLine();
                Int32.TryParse(input, out int bookId);
                var book = context.Books
                            .FirstOrDefault(b => b.BookId == bookId);      
                return book;
            }
        }

        public static int GetِAllNumberOfBooks()
        {
            using (var context = new BooksMDBContext())
            {
                var countBooks = context.Books.Where(b => b.IsDeleted == false).Count();
                return countBooks;
            }
        }

        public static void GetBriefInfoAboutBooks()
        {
            using (var context = new BooksMDBContext())
            {
                var books = context.Books
                             .Select(b => new { BookId = b.BookId,
                                                Title = b.Title,
                                                AvailableCopies = b.AvailableCopies
                                                })
                             .ToList();
                foreach (var book in books)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"Book number: {book.BookId}");
                    Console.WriteLine($"Book title: {book.Title}");
                    Console.WriteLine($"Copies of the book are available: {book.AvailableCopies}");
                    Console.WriteLine("-----------------------------------");
                }
                var totalNumberOfCopies = context.Books.Sum(b => b.AvailableCopies);
                Console.WriteLine($"Total number of copies: {totalNumberOfCopies}");
            }
        }
    }
}
