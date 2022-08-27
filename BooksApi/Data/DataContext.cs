using Microsoft.EntityFrameworkCore;
using BooksApi.Models;
namespace BooksApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Book> Books { get; set; }
    }
}
