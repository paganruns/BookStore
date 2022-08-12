using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class QGetGenresDetail
    {
        public int GenreIDtoGet {get; set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public QGetGenresDetail(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(x=> x.Id == GenreIDtoGet).SingleOrDefault();
            if (genre is null)
                throw new InvalidOperationException("genre is not found");

            GenresDetailViewModel returnObj = _mapper.Map<GenresDetailViewModel>(genre);

            return returnObj;
        }
    }

     public class GenresDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }



}