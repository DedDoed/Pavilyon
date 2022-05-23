using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;

namespace Pavilyon.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string ProjectName { get; set; }
        public Guid UserId { get; set; }
    }
    class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IAppDbContext _dbContext;
        public CreateProjectCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
            };

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var projectMember = new ProjectMember()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                IsCreator = true,
                ProjectId = project.Id
            };
            
            await _dbContext.ProjectMembers.AddAsync(projectMember, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return project.Id;
        }
    }
}
