using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyApp.Common;
using MyApp.DBOperation;

namespace MyApp.BookOperations.GetBooksById
{
    public class GetBookByIdQuery
    {
        public int bookId {get; set;}
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(BookStoreDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public BooksViewModelById Handle()
        {
            Book? book = _dbContext.Books.Where(book => book.Id == bookId).SingleOrDefault();

            if (book != null)
            {
                BooksViewModelById vm = _mapper.Map<BooksViewModelById>(book);
                return vm;
            }
            else
            {
                throw new InvalidOperationException("Book is not found.");
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