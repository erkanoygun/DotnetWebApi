using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.DBOperation;

public class BookStoreDBContext : DbContext
{
    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {}

    public DbSet<Book> Books {get; set;} = null!;
    public DbSet<Genre> Genres {get; set;} = null!;
}