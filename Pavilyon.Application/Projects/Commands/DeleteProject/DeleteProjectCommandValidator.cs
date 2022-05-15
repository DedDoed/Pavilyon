using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Pavilyon.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(deleteProjectCommand => deleteProjectCommand.CreatorId).NotEqual(Guid.Empty);
            RuleFor(deleteProjectCommand => deleteProjectCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
