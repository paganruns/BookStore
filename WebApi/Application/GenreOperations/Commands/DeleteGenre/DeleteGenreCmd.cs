using System;
using System.Linq;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{

    public class DeleteGenreCmd
    {
        public int GenreIDtoDelete{get;set;}

        private readonly BookStoreDbContext _context;

        public DeleteGenreCmd(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreIDtoDelete);
            if (genre is null)
              throw new NullReferenceException("genre is not found");

            _context.Remove(genre);
            _context.SaveChanges();
        }
         
    }
}