using MyApp.DBOperation;
using MyApp.DBOperations;

namespace MyApp.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int genreId { get; set; }
        private readonly IBookStoreDBContext _dbContext;

        public DeleteGenreCommand(IBookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.id == genreId);
            if (genre is null)
                throw new InvalidOperationException("Book genre is not found!");
            else
            {
                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
            }
        }
    }
}