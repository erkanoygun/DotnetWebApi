using Microsoft.EntityFrameworkCore;
using MyApp.DBOperations;
using MyApp.Entities;

namespace MyApp.DBOperation;

public class BookStoreDBContext : DbContext, IBookStoreDBContext
{
    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {}

    public DbSet<Book> Books {get; set;} = null!;
    public DbSet<Genre> Genres {get; set;} = null!;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}