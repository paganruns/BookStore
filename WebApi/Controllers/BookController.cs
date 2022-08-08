using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
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
            GetBooksQuery query = new GetBooksQuery(_context);
            var books = query.Handle();
            return Ok(books);
        }

        [HttpGet("{genreId}")]
        public Book GetBooksByGenre(int genreId)
        {
            var bookList = _context.Books.Where(x => x.GenreId == genreId).SingleOrDefault();
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
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = yenibook;
                command.Handle();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult BookPut(int id, [FromBody] Book guncelbook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return BadRequest();

            book.GenreId = guncelbook.GenreId != default ? guncelbook.GenreId : book.GenreId;
            book.PageCount = guncelbook.PageCount != default ? guncelbook.PageCount : book.PageCount;
            book.PublishDate = guncelbook.PublishDate != default ? guncelbook.PublishDate : book.PublishDate;
            book.Title = guncelbook.Title != default ? guncelbook.Title : book.Title;
            _context.SaveChanges();
            return Ok(book);


        }

        [HttpDelete("{id}")]
        public IActionResult BookDelete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok(book);
        }


    }



}