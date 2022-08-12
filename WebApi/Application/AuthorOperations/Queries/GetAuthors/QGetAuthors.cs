using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{

    public class QGetAuthors
    {
        private readonly BookStoreDbContext _context;

        public QGetAuthors(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        public List<GetAuthorsViewModel> Handle()
        {
            var author = _context.Authors.OrderByDescending(x => x.Id).ToList<Author>();

            List<GetAuthorsViewModel> authorViewModel = _mapper.Map<List<GetAuthorsViewModel>>(author);
            return authorViewModel;
        }

    }

    public class GetAuthorsViewModel
    {
        public int ID {get;set;}
        public string Name{get;set;}
        public string LastName {get;set;}
        public DateTime BirthDate {get;set;}
    }
}
