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
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public Guid CreatorId { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
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
                await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id == request.Id, cancellationToken);

            if (entity == null || entity.CreatorId != request.CreatorId)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            entity.ProjectName = request.ProjectName;
            entity.Tags = request.Tags;
            entity.ShortDescription = request.ShortDescription;
            entity.Description = request.Description;
            entity.Attachments = request.Attachments;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
