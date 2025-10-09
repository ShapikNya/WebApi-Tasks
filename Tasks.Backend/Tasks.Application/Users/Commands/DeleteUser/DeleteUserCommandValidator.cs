using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
         public DeleteUserCommandValidator()
         {
            RuleFor(deleteUserCommand => deleteUserCommand.Id).NotEqual(Guid.Empty);
         }
    }
}
