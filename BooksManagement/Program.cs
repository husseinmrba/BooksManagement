using BooksManagement_DataAccess;
using BooksManagement_DataAccess.DatabaseControl;
using BooksManagement_DataAccess.DefaultInfo;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!UserControl.IsAddedDefaultUsers())
            {
                DefaultInfo.AddDefaultUsers();
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (UserControl.IsUserExist(username, password))
            {
                Console.WriteLine("Logged in successfully.");
                Console.WriteLine("-----------------------------------------------");
                int numberOfBooks = BookControl.GetِAllNumberOfBooks();
                Console.WriteLine($"Tho total number of books: {numberOfBooks}");
                while (true)
                {
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("Please choose a transaction number:");
                    Console.WriteLine("  0-Logout.");
                    Console.WriteLine("  1-Show brief information about books and the total number of copies present.");
                    Console.WriteLine("  2-View book information.");
                    Console.WriteLine("  3-Delete book.");
                    Console.WriteLine("  4-Modify the title and price of a book.");
                    string operation = Console.ReadLine();
                    if (operation.Contains("0"))
                    {
                        Console.WriteLine("Signed out successfully");
                        break;
                    }
                    switch (operation)
                    {
                        case "1":
                            BookControl.GetBriefInfoAboutBooks();
                            break;
                        case "2":
                            var book = BookControl.GetBookInfo();
                            BookControl.PrintInfoBook(book);
                            break;
                        case "3":
                            BookControl.DeleteBook();
                            break;
                        case "4":
                            BookControl.ModifyBook();
                            break;
                        default:
                            Console.WriteLine("Please choose the number of one of the available operations");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("This user does not exist.");
            }



        }
    }
}