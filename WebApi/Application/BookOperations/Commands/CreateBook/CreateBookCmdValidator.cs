using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.AuthorID).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.PageCount).GreaterThan(5);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now);

        }
    }

}

