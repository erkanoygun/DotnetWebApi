using FluentValidation;

namespace MyApp.BookOperations.GetBooksById
{
    public class GetBookByIdValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdValidator()
        {
           RuleFor(query => query.bookId).GreaterThan(0);
        }
    }
}