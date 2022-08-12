using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.GetBookDetail
{

    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int bookID { get; set; }


        public GetBookDetailQuery(IBookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Include(x=> x.Author).Include(x=> x.Genre).Where(book => book.Id == bookID).Reverse().FirstOrDefault();
            if (book == null)
            {
                throw new InvalidOperationException("Book not found");
            }

            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);

            return vm;
        }

    }

      public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
            public string Author {get;set;}
        }


}
