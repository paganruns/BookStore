using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{

    public class QGetAuthorDetail
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorID;

        public QGetAuthorDetail(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;

        public GetAuthorsDetailViewModel Handle()
        {
            var author = _context.Authors.Where(x => x.Id == AuthorID).SingleOrDefault();
            if (author == null)
                throw new InvalidOperationException("author wasnt found");

            
            GetAuthorsDetailViewModel vm = _mapper.Map<GetAuthorsDetailViewModel>(author);

            return vm;

        }

    }

    public class GetAuthorsDetailViewModel
    {
        public string Name {get;set;}
        public string LastName {get;set;}
        public DateTime BirthDate {get;set;}
    }
}
