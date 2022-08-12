using System;
using System.Linq;
using FluentValidation;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{

    public class CreateGenreCommandValidator : AbstractValidator <CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(cmd=> cmd.Model.Name).MinimumLength(4);
        } 
    }


}