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
using WebApi.DBOperations;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /*  private static List<Book> BookList = new List<Book>()
  {
      new Book{Id=1, Title="Alice", GenreId=1, PageCount=100, PublishDate= new DateTime(2020,01,01)},
      new Book{Id=2, Title="Dune", GenreId=2, PageCount=200, PublishDate= new DateTime(2020,02,01)},
      new Book{Id=3, Title="SaS", GenreId=3, PageCount=300, PublishDate= new DateTime(2020,03,01)},
      new Book{Id=4, Title="Cin Ali", GenreId=4, PageCount=400, PublishDate=DateTime.Now}
  }; */
        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var books = query.Handle();
            return Ok(books);
        }

        /*  [HttpGet("{genreId}")]
          public Book GetBooksByGenre(int genreId)
          {
              var bookList = _context.Books.Where(q => q.GenreId == genreId).SingleOrDefault();
              return bookList;
          }

          /* [HttpGet]
           public Book Get([FromQuery] string id)
           {
               var bookList = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
               return bookList;
           } */

        [HttpPost]
        public IActionResult BookAdd([FromBody] CreateBookModel yenibook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = yenibook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.bookID = id;
            result = query.Handle();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult BookPut(int id, [FromBody] UpdateBookModel guncelbook)
        {
            UpdateBookQuery command = new UpdateBookQuery(_context);
            command.BookIDtoUpdate = id;
            command.Model = guncelbook;
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult BookDelete(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookIDtoDelete = id;
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(id + " silindi");
        }
    }
}