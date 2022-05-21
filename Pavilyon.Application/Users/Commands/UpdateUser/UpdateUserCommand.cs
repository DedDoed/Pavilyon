using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Common.Exeptions;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pavilyon.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Avatar { get; set; }
        public string AboutMe { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IAppDbContext _dbContext;
        public UpdateUserCommandHandler(IAppDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.UserId);

            if (entity == null || entity.Id != request.UserId)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            entity.FirstName = request.FirstName;
            entity.MiddleName = request.MiddleName;
            entity.LastName = request.LastName;
            entity.DOB = request.DOB;
            entity.Avatar = request.Avatar;
            entity.AboutMe = request.AboutMe;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
