using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.UpdateBook
{

    public class UpdateBookQuery
    {
        public int BookIDtoUpdate { get; set; }
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbcontext;

        public UpdateBookQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Id == BookIDtoUpdate);
            if (book == null)
                throw new InvalidOperationException("Book not found");

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.AuthorID = Model.AuthorID != default ? Model.AuthorID : book.AuthorID;
            _dbcontext.SaveChanges();
        }

    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorID {get;set;}

    }
}