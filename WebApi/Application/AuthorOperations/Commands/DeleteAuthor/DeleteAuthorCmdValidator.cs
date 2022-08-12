using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteAuthorCmd>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.AuthorIDtoDelete).GreaterThan(0);
        }
    }

}