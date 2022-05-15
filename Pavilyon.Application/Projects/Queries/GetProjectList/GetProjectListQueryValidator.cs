using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Pavilyon.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQueryValidator : AbstractValidator<GetProjectListQuery>
    {
        public GetProjectListQueryValidator()
        {
            RuleFor(getProjectListQuery => getProjectListQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
