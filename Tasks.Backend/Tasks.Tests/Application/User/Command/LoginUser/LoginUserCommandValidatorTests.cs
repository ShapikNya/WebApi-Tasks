using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Users.Commands.LogingUsrt;
using Tasks.Application.Users.Commands.LoginUser;

namespace Tasks.Tests.Application.User.Command.LoginUser
{
    public class LoginUserCommandValidatorTests
    {
        private readonly LoginUserCommandValidator _validator;

        public LoginUserCommandValidatorTests()
        {
            _validator = new LoginUserCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            // Arrange
            var command = new LoginUserCommand { Email = "", Password = "Password123!" };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Password_Is_Empty()
        {
            // Arrange
            var command = new LoginUserCommand { Email = "test@example.com", Password = "" };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Password);
        }

        [Fact]
        public void Should_Not_Have_Error_For_Valid_Command()
        {
            // Arrange
            var command = new LoginUserCommand { Email = "test@example.com", Password = "Password123!" };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.Email);
            result.ShouldNotHaveValidationErrorFor(c => c.Password);
        }
    }
}
