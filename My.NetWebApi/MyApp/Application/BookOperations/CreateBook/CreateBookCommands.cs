using AutoMapper;
using MyApp.DBOperation;

namespace MyApp.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;} = null!;

        private readonly BookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);
            if(book is not null)
                throw new InvalidOperationException("Book is already exist!");

            book = _mapper.Map<Book>(Model);

            _dbContext.Books.Add(book);
        }
    }
}

public class CreateBookModel
{
    public string Title { get; set; } = null!;
    public DateTime publishDate { get; set; }
    public int PageCount { get; set; }
    public int genreId { get; set; }
}