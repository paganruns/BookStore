using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCmd
    {
        public int AuthorIDtoDelete { get; set; }
        private readonly IBookStoreDbContext _context;

        public DeleteAuthorCmd(IBookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorIDtoDelete);
            if (author is null)
                throw new InvalidOperationException("author not out there");

            var authorsbook = _context.Books.Where(x=> x.AuthorID == AuthorIDtoDelete).Any();
            if (authorsbook)
                throw new InvalidProgramException("he has a book on release");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }



    }
}