using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.DBOperations;

namespace WebApi
{
    public class DataGeneratorClass
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }

                context.Books.AddRange(
                    new Book
                    {
                    //    Id = 1,
                        Title = "Alice",
                        GenreId = 1,
                        PageCount = 100,
                        PublishDate = new DateTime(2020, 01, 01)
                    },
                    new Book
                    {
                   //    Id = 2,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2020, 02, 01)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "SaS",
                        GenreId = 3,
                        PageCount = 300,
                        PublishDate = new DateTime(2020, 03, 01)
                    },
                    new Book
                    {
                      //  Id = 4,
                        Title = "Cin Ali",
                        GenreId = 1,
                        PageCount = 400,
                        PublishDate = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }

}