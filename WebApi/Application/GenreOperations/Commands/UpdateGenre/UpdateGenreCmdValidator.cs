using System;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreCmdValidator : AbstractValidator<UpdateGenreCmd>
    {
        public UpdateGenreCmdValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(command => command.Model.Name != string.Empty);
        }
    } 

}
