using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{

    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public int bookID { get; set; }


        public GetBookDetailQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(book => book.Id == bookID).Reverse().FirstOrDefault();
            if (book == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            BookDetailViewModel vm = new BookDetailViewModel();

            vm.Title = book.Title;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");

            return vm;
        }

    }

      public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }


}
