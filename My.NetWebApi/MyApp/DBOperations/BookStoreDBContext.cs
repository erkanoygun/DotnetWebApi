using Microsoft.EntityFrameworkCore;

namespace MyApp.DBOperation;

public class BookStoreDBContext : DbContext
{
    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {}

    public DbSet<Book> Books {get; set;} = null!;
}