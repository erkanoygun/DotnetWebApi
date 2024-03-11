using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MyApp.BookOperations.DeleteCommand
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.bookId).GreaterThan(0);
        }
    }
}