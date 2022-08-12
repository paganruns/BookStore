using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.AddAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.CreateBook.CreateBookCommand;


namespace WebApi.Commons
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt=> opt.MapFrom(src => src.Author.ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt=> opt.MapFrom(src => src.Author.ToString()));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, CreateGenreModel>();
            CreateMap<Genre, UpdateGenreModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<AddAuthorModel, Author>();
            CreateMap<Author, GetAuthorsViewModel>();
            CreateMap<Author, GetAuthorsDetailViewModel>();

        }
    }
}