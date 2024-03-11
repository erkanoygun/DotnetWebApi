using MyApp.Common;
using MyApp.DBOperation;

namespace MyApp.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDBContext _dbContext;

        public GetBooksQuery(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x=> x.Id).ToList<Book>();
            List<BooksViewModel> vmList = new List<BooksViewModel>();
            foreach(var book in bookList)
            {
                vmList.Add(
                    new BooksViewModel(){
                        Title = book.Title!,
                        Genre = ((GenreEnum)book.GenereId).ToString(),
                        PublisDate = book.PublisDate.Date.ToString("dd/MM/yyy"),
                        PageCount = book.PageCount
                    }
                );
            }

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