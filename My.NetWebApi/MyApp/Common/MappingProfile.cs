using AutoMapper;
using MyApp.Application.GenreOperations.Querys.GetGenreQueryDetail;
using MyApp.Entities;
using static MyApp.Application.GenreOperations.Querys.GetGenresQuery;

namespace MyApp.Common
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModelById>().ForMember(dets=>dets.Genre,opt=>opt.MapFrom(src=> src.Genre.name));
            CreateMap<Book, BooksViewModel>().ForMember(dets=>dets.Genre,opt=>opt.MapFrom(src=> src.Genre.name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}