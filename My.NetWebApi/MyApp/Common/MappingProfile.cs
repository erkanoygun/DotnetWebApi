using AutoMapper;
using MyApp.BookOperations.GetBooksById;

namespace MyApp.Common
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModelById>().ForMember(dets=>dets.Genre,opt=>opt.MapFrom(src=> ((GenreEnum)src.GenereId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dets=>dets.Genre,opt=>opt.MapFrom(src=> ((GenreEnum)src.GenereId).ToString()));
        }
    }
}