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

        private readonly IBookStoreDbContext _context;

        public DeleteGenreCmd(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreIDtoDelete);
            if (genre is null)
              throw new NullReferenceException("genre is not found");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
         
    }
}