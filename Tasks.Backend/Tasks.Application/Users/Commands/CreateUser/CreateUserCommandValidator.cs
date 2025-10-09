using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Commands.CreateTask;

namespace Tasks.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обязателен")
            .MaximumLength(32).WithMessage("Email не должен превышать 32 символа")
            .Must(email => email.Contains("@"))
            .WithMessage("Email должен содержать символ '@'")
            .Matches("^[a-zA-Z0-9@_.-]*$")
            .WithMessage("Пароль должен содержать только латинские буквы и допустимые символы");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль обязателен")
            .MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов")
            .MaximumLength(16).WithMessage("Пароль должен содержать максимум 16 символов")
            .Matches("^[a-zA-Z0-9!@#$%^&*()_+=-]*$")
            .WithMessage("Пароль должен содержать только латинские буквы и допустимые символы");


        }
    }
}
