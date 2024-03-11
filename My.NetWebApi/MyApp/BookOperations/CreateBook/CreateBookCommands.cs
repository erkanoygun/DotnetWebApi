using MyApp.DBOperation;

namespace MyApp.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;} = null!;

        private readonly BookStoreDBContext _dbContext;

        public CreateBookCommand(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title == Model.Title);
            if(book is not null)
                throw new InvalidOperationException("Book is already exist!");

            book = new Book
            {
                Title = Model.Title,
                PublisDate = Model.publishDate,
                PageCount = Model.PageCount,
                GenereId = Model.genreId
            };

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