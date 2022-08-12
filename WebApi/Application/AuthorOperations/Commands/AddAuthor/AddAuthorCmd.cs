using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.AddAuthor
{
    public class AddAuthorCmd
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AddAuthorModel Model {get;set;}

        public AddAuthorCmd(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Name == Model.Name && x.LastName == Model.LastName);
            if (author is not null)
                throw new InvalidOperationException("author already exists");

            author = new Author();
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }


    }

    public class AddAuthorModel
    {

        public string Name {get;set;}
        public string LastName {get;set;}
        public DateTime BirthDate {get;set;}
    }



    }