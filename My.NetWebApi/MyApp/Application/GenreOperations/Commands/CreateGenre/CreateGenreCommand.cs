using System;
using MyApp.DBOperation;
using MyApp.Entities;

namespace MyApp.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel model {get; set;} = null!;
        private readonly BookStoreDBContext _dbContext;

        public CreateGenreCommand(BookStoreDBContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.name == model.name);
            if(genre is not null)
                throw new InvalidOperationException("The book genre is alreayd exist");

            genre = new Genre
            {
                name = model.name
            };
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public class CreateGenreModel
        {
            public string name {get;set;} = null!;
        }
    }
}