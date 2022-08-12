using System;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCmdValidator : AbstractValidator<DeleteGenreCmd>
    {
        public DeleteGenreCmdValidator()
        {
            RuleFor(command => command.GenreIDtoDelete).GreaterThan(0);
        }
    }

}

