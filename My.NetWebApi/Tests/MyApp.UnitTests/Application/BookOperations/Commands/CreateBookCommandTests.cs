using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MyApp.BookOperations.CreateBook;
using MyApp.DBOperation;
using MyApp.UnitTests.TestSetup;

namespace MyApp.UnitTests.Application.BookOperations.Commands
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDBContext _context;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.context;
            _mapper = testFixture.mapper;
        }

        [Fact]
        public void TestMethod1()
        {
            var book = new Book(){Title = "Test Book",PageCount=100,Id=1,GenereId=2,PublisDate= new System.DateTime(1998,01,01)};
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            command.Model = new CreateBookModel(){Title = book.Title};

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be("Book is already exist!");
        }
    }
}