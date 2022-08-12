using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(command => command.BookIDtoUpdate).GreaterThan(0);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
        }
    }
}