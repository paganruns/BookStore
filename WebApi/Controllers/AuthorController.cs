using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.AddAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            QGetAuthors query = new(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("id")]
        public IActionResult GetAuthorDetails(int id)
        {
            QGetAuthorDetail query = new(_context,_mapper);
            query.AuthorID = id;
            QGetAuthorDetailValidator validator = new ();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            System.Console.WriteLine(obj);
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AddAuthorModel newAuthor)
        {
            AddAuthorCmd cmd = new(_context,_mapper);
            cmd.Model = newAuthor;
            AddAuthorCmdValidator validator = new();
            validator.ValidateAndThrow(cmd);           
            cmd.Handle();
            return Ok(cmd);
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel updatedAuthor, int id)
        {
            UpdateAuthorCmd cmd = new(_context);
            cmd.AuthorIDtoUpdate = id;
            cmd.Model = updatedAuthor;
            UpdateAuthorCmdValidator vld = new();
            vld.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok(cmd);
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCmd cmd = new DeleteAuthorCmd(_context);
            cmd.AuthorIDtoDelete = id;
            DeleteBookCommandValidator vld = new();
            vld.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok(cmd);
        }

    }
}