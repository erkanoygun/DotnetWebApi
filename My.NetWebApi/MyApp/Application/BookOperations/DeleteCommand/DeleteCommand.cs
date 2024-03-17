using MyApp.DBOperation;
using MyApp.DBOperations;

namespace MyApp.BookOperations.DeleteCommand
{
    public class DeleteCommand
    {
        public int bookId { get; set; }
        private readonly IBookStoreDBContext _dbContext;

        public DeleteCommand(IBookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);
            if (book is null)
                throw new InvalidOperationException("Book is not found!");
            else
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }

        }
    }
}