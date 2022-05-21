using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Users.Queries.GetUserData
{
    public class GetUserDataQueryValidator : AbstractValidator<GetUserDataQuery>
    {
        public GetUserDataQueryValidator()
        {
            RuleFor(getUserDataQuery => getUserDataQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
