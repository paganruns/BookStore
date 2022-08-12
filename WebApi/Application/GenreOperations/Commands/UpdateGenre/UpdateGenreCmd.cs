using System;
using System.Linq;
using AutoMapper;
using WebApi.Commons;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{

    public class UpdateGenreCmd
    {
        public int GenreIDtoUpdate { get; set; }
        public UpdateGenreModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateGenreCmd(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genreupdate = _context.Genres.SingleOrDefault(x => x.Id == GenreIDtoUpdate);
            if (genreupdate is null)
                throw new InvalidOperationException("that was not found");

            if (_context.Genres.Any(x => x.Name.ToUpper() == Model.Name.ToUpper() && x.Id != GenreIDtoUpdate))
            throw new InvalidOperationException("that was already exist with another number");

            genreupdate.Name = Model.Name.Trim() == default ? genreupdate.Name : Model.Name;
            genreupdate.IsActive = Model.IsActive;
            _context.SaveChanges();
        }

    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

    }


}