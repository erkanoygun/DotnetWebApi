using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Common;
using MyApp.DBOperation;

namespace MyApp.BookOperations.GetBooksById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDBContext _dbContext;

        public GetBookByIdQuery(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public BooksViewModelById Handle(int id)
        {
            Book? book = _dbContext.Books.Where(book => book.Id == id).SingleOrDefault();

            if (book != null)
            {
                return new BooksViewModelById()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenereId).ToString(),
                    PublisDate = book.PublisDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
                };
            }
            else
            {
                return new BooksViewModelById()
                {
                    Title = _dbContext.Books.ToList()[0].Title,
                    Genre = ((GenreEnum)_dbContext.Books.ToList()[0].GenereId).ToString(),
                    PublisDate = _dbContext.Books.ToList()[0].PublisDate.Date.ToString("dd/MM/yyy"),
                    PageCount = _dbContext.Books.ToList()[0].PageCount
                };
            }

        }



    }
}

public class BooksViewModelById
{
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int PageCount { get; set; }
    public string PublisDate { get; set; } = null!;
}