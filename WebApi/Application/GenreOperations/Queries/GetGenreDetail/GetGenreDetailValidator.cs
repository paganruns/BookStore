using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailValidator: AbstractValidator<QGetGenresDetail>
    {
        public GetGenreDetailValidator()
        {
            RuleFor(q=> q.GenreIDtoGet).GreaterThan(0);
        }

    }

}