using MyApp.DBOperation;
using MyApp.Entities;

namespace MyApp.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDBContext context)
        {
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
        }
    }
}