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
        
        private readonly IAppDbContext _dbContext;
        public GetProjectDescriptionQueryHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<ProjectDescriptionDto> Handle(GetProjectDescriptionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .Include(project => project.Team)
                .Include(project => project.Tags)
                .Include(project => project.Stages)
                .Include(project => project.Attachments)
                .Where(project => project.Id == request.Id)
                .Select(project => new ProjectDescriptionDto
                {
                    Id = project.Id,
                    Attachments = project.Attachments,
                    Stages = project.Stages,
                    Contacts = project.Contacts,
                    RequieredPersonal = project.RequieredPersonal,
                    ProjectObjectives = project.ProjectObjectives,
                    ProjectTargets = project.ProjectTargets,
                    Description = project.Description,
                    ProjectName = project.ProjectName,
                    ShortDescription = project.ShortDescription,
                    Tags = project.Tags,
                    Team = project.Team
                })
                .FirstOrDefaultAsync();
            var creator = entity.Team.Find(user => user.IsCreator);

            if (entity == null || creator.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return entity;
        }
    }
}
