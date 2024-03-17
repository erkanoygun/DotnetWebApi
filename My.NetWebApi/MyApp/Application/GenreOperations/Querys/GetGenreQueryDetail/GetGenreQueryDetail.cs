using AutoMapper;
using MyApp.DBOperation;
using MyApp.DBOperations;
using MyApp.Entities;

namespace MyApp.Application.GenreOperations.Querys.GetGenreQueryDetail
{
    public class GetGenreQueryDetail
    {
        public int genreId { get; set; }
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreQueryDetail(IBookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            Genre? genre = _dbContext.Genres.SingleOrDefault(x => x.isActive && x.id == genreId);
            if(genre is null)
                throw new InvalidOperationException("Book genre is not found");
            
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }

    public class GenreDetailViewModel
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
    }
}


