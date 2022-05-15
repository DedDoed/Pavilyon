using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Common.Exeptions;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Pavilyon.Application.Projects.Queries.GetProjectDescription
{
    public class GetProjectDescriptionQuery : IRequest<ProjectDescriptionDto>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
    public class GetProjectDescriptionQueryHandler : IRequestHandler<GetProjectDescriptionQuery, ProjectDescriptionDto>
    {
        
        private readonly IProjectsDbContext _dbContext;
        public GetProjectDescriptionQueryHandler(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<ProjectDescriptionDto> Handle(GetProjectDescriptionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .Where(project => project.Id == request.Id)
                .Select(project => new ProjectDescriptionDto
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    CreatorId = project.CreatorId,
                    Tags = project.Tags,
                    Attachments = project.Attachments,
                    Description = project.Description,
                    ShortDescription = project.ShortDescription
                })
                .FirstOrDefaultAsync();

            if (entity == null || entity.CreatorId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return entity;
        }
    }
}
