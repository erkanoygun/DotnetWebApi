using FluentValidation;

namespace MyApp.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.genreId).GreaterThan(0);
        }
    }
}