using BooksManagement_Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BooksManagement_DataAccess
{
    public class BooksMDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB;" +
                                        "Initial Catalog = BooksManagement");
        }

        
    }
}