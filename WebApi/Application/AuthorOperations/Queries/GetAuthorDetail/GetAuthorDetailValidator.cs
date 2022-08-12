using FluentValidation;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class QGetAuthorDetailValidator: AbstractValidator<QGetAuthorDetail>
    {
        public QGetAuthorDetailValidator()
        {
            RuleFor(q=> q.AuthorID).GreaterThan(0);
        }

    }

}