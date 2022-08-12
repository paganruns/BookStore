using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.AddAuthor
{
    public class AddAuthorCmdValidator : AbstractValidator<AddAuthorCmd>
    {
        public AddAuthorCmdValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now);

        }
    }

}
