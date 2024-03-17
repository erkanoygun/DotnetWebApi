using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Common;
using MyApp.DBOperation;

namespace MyApp.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public BookStoreDBContext context {get; set;} = null!;
        public IMapper mapper { get; set; } = null!;

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDBContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            context = new BookStoreDBContext(options);
            context.Database.EnsureCreated();

            context.AddBooks();
            context.AddGenres();
            context.SaveChanges();

            mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }

    }
}