using AutoMapper;
using MyApp.DBOperation;
using MyApp.DBOperations;

namespace MyApp.BookOperations.GetBooksById
{
    public class GetBookByIdQuery
    {
        public int bookId {get; set;}
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(IBookStoreDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public BooksViewModelById Handle()
        {
            Book? book = _dbContext.Books.Where(book => book.Id == bookId).SingleOrDefault();
            //Book? book = _dbContext.Books.Include(x=> x.Genre).Where(book => book.Id == bookId).SingleOrDefault();
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