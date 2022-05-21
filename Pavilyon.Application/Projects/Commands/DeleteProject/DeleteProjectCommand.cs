using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Common.Exeptions;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;

namespace Pavilyon.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

    }
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IAppDbContext _dbContext;
        public DeleteProjectCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .Include(project => project.Team)
                .FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);
            var creator = entity.Team.Find(user => user.IsCreator);

            if (entity == null || creator.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            _dbContext.Projects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
