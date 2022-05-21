using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Common.Exeptions;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pavilyon.Application.Users.Queries.GetUserData
{
    public class GetUserDataQuery : IRequest<UserDataDto>
    {
        public Guid UserId { get; set; }
    }
    public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDataDto>
    {
        private readonly IAppDbContext _dbContext;
        public GetUserDataQueryHandler(IAppDbContext dbContext) => _dbContext = dbContext;
        public async Task<UserDataDto> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken);

            if(entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            return new UserDataDto
            {
                Id = entity.Id,
                AboutMe = entity.AboutMe,
                Avatar = entity.Avatar,
                DOB = entity.DOB,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.MiddleName,
                PhoneNumber = entity.PhoneNumber
            };
        }
    }
}
