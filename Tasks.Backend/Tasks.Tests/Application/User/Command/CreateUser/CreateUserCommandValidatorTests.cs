using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Users.Commands.CreateUser;

namespace Tasks.Tests.Application.User.Command.CreateUser
{
    public class CreateUserCommandValidatorTests
    {
        private readonly CreateUserCommandValidator _validator;

        public CreateUserCommandValidatorTests()
        {
            _validator = new CreateUserCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var command = new CreateUserCommand { Email = "", Password = "Password123!" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Email)
                  .WithErrorMessage("Email обязателен");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Does_Not_Contain_At()
        {
            var command = new CreateUserCommand { Email = "invalidemail.com", Password = "Password123!" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Email)
                  .WithErrorMessage("Email должен содержать символ '@'");
        }

        [Fact]
        public void Should_Have_Error_When_Email_Too_Long()
        {
            var command = new CreateUserCommand { Email = "thisemailiswaytoolongforthevalidator@example.com", Password = "Password123!" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Email)
                  .WithErrorMessage("Email не должен превышать 32 символа");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            var command = new CreateUserCommand { Email = "test@example.com", Password = "" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Password)
                  .WithErrorMessage("Пароль обязателен");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Too_Short()
        {
            var command = new CreateUserCommand { Email = "test@example.com", Password = "short" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Password)
                  .WithErrorMessage("Пароль должен содержать минимум 8 символов");
        }

        [Fact]
        public void Should_Have_Error_When_Password_Too_Long()
        {
            var command = new CreateUserCommand { Email = "test@example.com", Password = "ThisPasswordIsWayTooLong123!" };
            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.Password)
                  .WithErrorMessage("Пароль должен содержать максимум 16 символов");
        }

        [Fact]
        public void Should_Not_Have_Error_For_Valid_Command()
        {
            var command = new CreateUserCommand
            {
                Email = "valid@example.com",
                Password = "Password1!"
            };
            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
