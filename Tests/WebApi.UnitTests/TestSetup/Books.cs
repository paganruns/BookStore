using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                    new Book
                    {
                        Title = "Alice",
                        GenreId = 1,
                        PageCount = 100,
                        PublishDate = new DateTime(2020, 01, 01),
                        AuthorID = 1
                    },
                    new Book
                    {
                        //    Id = 2,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2020, 02, 01),
                        AuthorID = 2
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "SaS",
                        GenreId = 3,
                        PageCount = 300,
                        PublishDate = new DateTime(2020, 03, 01),
                        AuthorID = 1
                    },
                    new Book
                    {
                        //  Id = 4,
                        Title = "Cin Ali",
                        GenreId = 1,
                        PageCount = 400,
                        PublishDate = DateTime.Now,
                        AuthorID = 3
                    });
        }
    }
}