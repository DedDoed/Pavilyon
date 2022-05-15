using System.Text;
using MediatR;
using Pavilyon.Application.Interfaces;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Pavilyon.Domain;

namespace Pavilyon.Application.Projects.Queries.GetProjectList
{
    public class GetProjectListQuery : IRequest<IList<ProjectLookupDto>>
    {
        public Guid UserId { get; set; }
    }
    public class GetProjectListQueryHandler : IRequestHandler<GetProjectListQuery, IList<ProjectLookupDto>>
    {
        private readonly IProjectsDbContext _dbContext;

        public GetProjectListQueryHandler(IProjectsDbContext dbContext) => _dbContext = dbContext;

        public async Task<IList<ProjectLookupDto>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
        {
            var projectsQuery = await _dbContext.Projects
                .Where(project => project.CreatorId == request.UserId)
                .Select(project => new ProjectLookupDto
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName
                })
                .ToListAsync(cancellationToken);
            return projectsQuery;
        }
    }
}
