using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Pavilyon.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(updateProjectCommand => updateProjectCommand.CreatorId).NotEqual(Guid.Empty);
            RuleFor(updateProjectCommand => updateProjectCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProjectCommand => updateProjectCommand.ProjectName).NotEmpty().MaximumLength(50);
        }
    }
}
