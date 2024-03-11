using MyApp.DBOperation;

namespace MyApp.BookOperations.UpdateBookCommand
{
    public class UpdateBookCommand
    {
        public int bookId {get; set;}
        public UpdateBookModel updateModel {get; set;} = null!;
        private readonly BookStoreDBContext _dbContext;

        public UpdateBookCommand(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }



        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);

            if (book is not null)
            {
                book.GenereId = updateModel.genreId != default ? updateModel.genreId : book.GenereId;
                book.Title = updateModel.Title != default ? updateModel.Title : book.Title;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Book is not found!");
            }

        }
    }
}

public class UpdateBookModel
{
    public string Title { get; set; } = null!;
    public int genreId { get; set; }
}
