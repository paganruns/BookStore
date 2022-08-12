using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        public int BookIDtoDelete { get; set; }
        private readonly IBookStoreDbContext _dbcontext;

        public DeleteBookCommand(IBookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.Where(book => book.Id == BookIDtoDelete).SingleOrDefault();

            if (book == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
        }

    }

}