using MyApp.DBOperation;

namespace MyApp.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDBContext context)
        {
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
        }
    }
}