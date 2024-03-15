using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.DBOperation;

namespace MyApp.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int genreId { get; set; }
        public UpdateGenreModel updateModel { get; set; } = null!;
        private readonly BookStoreDBContext _dbContext;
        public UpdateGenreCommand(BookStoreDBContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.id == genreId);

            if(genre is null)
                throw new InvalidOperationException("Genre is not found!");
            if(_dbContext.Genres.Any(x=>x.name.ToLower() == updateModel.name.ToLower() && x.id != genreId))
                throw new InvalidOperationException("The book genre with the same name already exists.");
            
            genre.name = updateModel.name.Trim() != default ? updateModel.name : genre.name;
            genre.isActive = updateModel.isActive;
            _dbContext.SaveChanges();
        }


        public class UpdateGenreModel
        {
            public string name { get; set; } = null!;
            public bool isActive { get; set; }
        }
    }
}