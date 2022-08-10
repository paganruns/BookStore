using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Commons;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{

    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int bookID { get; set; }


        public GetBookDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(book => book.Id == bookID).Reverse().FirstOrDefault();
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
        }


}
