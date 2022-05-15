using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Pavilyon.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectName).NotEmpty().MaximumLength(50);
            RuleFor(createProjectCommand =>
                createProjectCommand.CreatorId).NotEqual(Guid.Empty);
        }
    }
}
