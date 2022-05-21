using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pavilyon.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateUserCommand => updateUserCommand.FirstName).MaximumLength(30);
            RuleFor(updateUserCommand => updateUserCommand.MiddleName).MaximumLength(30);
            RuleFor(updateUserCommand => updateUserCommand.LastName).MaximumLength(30);
            RuleFor(updateUserCommand => updateUserCommand.AboutMe).MaximumLength(200);
        }
    }
}
