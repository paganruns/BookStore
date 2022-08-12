using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            QGetGenres query = new(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);

        }

        [HttpGet("id")]
        public IActionResult GetGenreDetail(int id)
        {
            QGetGenresDetail query = new(_context,_mapper);
            query.GenreIDtoGet = id;
            GetGenreDetailValidator validator = new();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand cmd = new(_context);
            cmd.Model = newGenre;
            CreateGenreCommandValidator validator = new();
            validator.ValidateAndThrow(cmd);

            cmd.Handle();
            
            return Ok(cmd);

        } 

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updatedGenre)
        {
            UpdateGenreCmd cmd = new(_context);
            cmd.GenreIDtoUpdate = id;
            cmd.Model = updatedGenre;
            UpdateGenreCmdValidator valider = new();
            valider.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok(cmd);
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCmd cmd = new(_context);
            cmd.GenreIDtoDelete = id;
            DeleteGenreCmdValidator valider = new();
            valider.ValidateAndThrow(cmd);
            cmd.Handle();
            return Ok(cmd);
        }

        
    }
}
