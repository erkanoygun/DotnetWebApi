using FluentValidation;

namespace MyApp.Application.GenreOperations.Querys.GetGenreQueryDetail
{
    public class GetGenreQueryDetailValidator : AbstractValidator<GetGenreQueryDetail>
    {
        public GetGenreQueryDetailValidator()
        {
            RuleFor(query => query.genreId).GreaterThan(0);
        }
    }
}