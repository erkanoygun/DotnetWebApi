using AutoMapper;
using MyApp.Common;
using MyApp.DBOperation;

namespace MyApp.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDBContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=> x.Id).ToList<Book>();
            List<BooksViewModel> vmList  = _mapper.Map<List<BooksViewModel>>(bookList);

            return vmList;
        }
    }
}


public class BooksViewModel
{
    public string Title { get; set; } = null!;
    public string Genre {get; set;} = null!;
    public int PageCount {get; set;}
    public string PublisDate {get; set;} = null!;
}