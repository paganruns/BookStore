using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.GetBooks
{

    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.Include(x=> x.Genre).Include(x=> x.Author).OrderBy(x => x.Id).ToList<Book>();
            List <BooksViewModel> booksViewModel = _mapper.Map<List<BooksViewModel>>(bookList);
            return booksViewModel;

        }

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author {get;set;}

    }

}