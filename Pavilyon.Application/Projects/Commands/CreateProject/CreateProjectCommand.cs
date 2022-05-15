using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;

namespace Pavilyon.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string ProjectName { get; set; }
        public Guid CreatorId { get; set; }
    }
    class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectsDbContext _dbContext;
        public CreateProjectCommandHandler(IProjectsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project()
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                CreatorId = request.CreatorId,
                Tags = "",
                ShortDescription = "",
                Description = "",
                Attachments = new List<Attachment>() { }
            };
            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return project.Id;
        }
    }
}
