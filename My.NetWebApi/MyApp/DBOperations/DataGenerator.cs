using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.DBOperation;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
        {
            if (context.Books.Any())
                return;

            
            context.Genres.AddRange(
                new Genre{
                    name = "Personal Growth"
                },
                new Genre{
                    name = "Science Finction"
                },
                new Genre{
                    name = "Noval"
                }
            );
            
            context.Books.AddRange(
                new Book
                {
                    Title = "Sefiller",
                    GenereId = 1,
                    PageCount = 200,
                    PublisDate = new DateTime(1998, 6, 11)
                },
                new Book
                {
                    Title = "Kürk mantolu madonna",
                    GenereId = 2,
                    PageCount = 350,
                    PublisDate = new DateTime(1885, 6, 11)
                },
                new Book
                {
                    Title = "Anna Karenna",
                    GenereId = 3,
                    PageCount = 621,
                    PublisDate = new DateTime(1795, 6, 11)
                }
            );

            context.SaveChanges();
        }
    }
}