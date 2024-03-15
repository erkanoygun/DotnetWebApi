using FluentValidation;

namespace MyApp.BookOperations.UpdateBookCommand
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.updateModel.genreId).GreaterThan(0);
            RuleFor(command => command.updateModel.Title).NotEmpty().MinimumLength(3);
        }
    }
}