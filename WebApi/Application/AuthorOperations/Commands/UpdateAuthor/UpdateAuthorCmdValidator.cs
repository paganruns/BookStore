using System;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCmdValidator : AbstractValidator<UpdateAuthorCmd>
    {
        public UpdateAuthorCmdValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.BirthDate).NotEmpty().LessThan(DateTime.Now);

        }
    }

}
