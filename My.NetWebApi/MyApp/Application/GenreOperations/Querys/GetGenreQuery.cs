using AutoMapper;
using MyApp.DBOperation;
using MyApp.DBOperations;

namespace MyApp.Application.GenreOperations.Querys
{
    public class GetGenresQuery
    {
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenresQuery(IBookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x => x.isActive).OrderBy(x => x.id);
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genres);
            return vm;
        }

        public class GenresViewModel
        {
            public int id { get; set; }
            public string name { get; set; } = null!;
        }
    }
}


