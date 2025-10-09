using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Users.Commands.DeleteUser;
using Tasks.Application.Users.Commands.LogingUsrt;

namespace Tasks.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(loginUserCommand => loginUserCommand.Email).NotEqual(String.Empty);
            RuleFor(loginUserCommand => loginUserCommand.Password).NotEqual(String.Empty);
        }
    }
}
