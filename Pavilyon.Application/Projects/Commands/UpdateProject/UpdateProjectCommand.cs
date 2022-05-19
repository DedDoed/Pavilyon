using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pavilyon.Application.Common.Exeptions;
using Pavilyon.Application.Interfaces;
using Pavilyon.Domain;

namespace Pavilyon.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectMember> Team { get; set; }
        public List<Tag> Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ProjectTargets { get; set; }
        public string ProjectObjectives { get; set; }
        public string RequieredPersonal { get; set; }
        public string Contacts { get; set; }
        public List<Stage> Stages { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectsDbContext _dbContext;
        public UpdateProjectCommandHandler(IProjectsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Projects
                .Include(project => project.Team)
                .FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);
            var creator = entity.Team.Find(user => user.IsCreator);

            if (entity == null || creator.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            entity.ProjectName = request.ProjectName;
            entity.Team = request.Team;
            entity.Tags = request.Tags;
            entity.ShortDescription = request.ShortDescription;
            entity.Description = request.Description;
            entity.ProjectTargets = request.ProjectTargets;
            entity.ProjectObjectives = request.ProjectObjectives;
            entity.RequieredPersonal = request.RequieredPersonal;
            entity.Contacts = request.Contacts;
            entity.Stages = request.Stages;
            entity.Attachments = request.Attachments;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
