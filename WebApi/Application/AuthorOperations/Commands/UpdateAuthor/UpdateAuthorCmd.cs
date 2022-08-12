using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCmd
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorIDtoUpdate { get; set; }
        public UpdateAuthorModel Model {get;set;}

        public UpdateAuthorCmd(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorIDtoUpdate);
            if (author is null)
            {
                throw new InvalidOperationException("author was not found");
            }

            //book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

            _context.SaveChanges();

        }


    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

    }
}