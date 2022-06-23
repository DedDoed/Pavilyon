using System;
using FluentValidation;

namespace Pavilyon.Application.Projects.Queries.GetProjectDescription
{
    public class GetProjectDescriptionQueryValidator : AbstractValidator<GetProjectDescriptionQuery>
    {
        public GetProjectDescriptionQueryValidator()
        {
            RuleFor(getProjectDescriptionQuery => getProjectDescriptionQuery.Id).NotEqual(Guid.Empty);
            RuleFor(getProjectDescriptionQuery => getProjectDescriptionQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
