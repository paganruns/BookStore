using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{

    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public GetBooksQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.OrderBy(x => x.Id).ToList<Book>();
            List <BooksViewModel> booksViewModel = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                booksViewModel.Add(new BooksViewModel
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.ToString("dd/MM/yyyy")
                });
            }
            return booksViewModel;

        }




    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }

    }



}