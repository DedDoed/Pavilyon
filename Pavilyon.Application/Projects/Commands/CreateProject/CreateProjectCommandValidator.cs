using System;
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
                createProjectCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
