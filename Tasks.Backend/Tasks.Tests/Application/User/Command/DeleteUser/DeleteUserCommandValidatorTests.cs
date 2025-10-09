using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Users.Commands.DeleteUser;

namespace Tasks.Tests.Application.User.Command.DeleteUser
{
    public class DeleteUserCommandValidatorTests
    {
        private readonly DeleteUserCommandValidator _validator;

        public DeleteUserCommandValidatorTests()
        {
            _validator = new DeleteUserCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            // Arrange
            var command = new DeleteUserCommand { Id = Guid.Empty };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Id);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Id_Is_Valid()
        {
            // Arrange
            var command = new DeleteUserCommand { Id = Guid.NewGuid() };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(c => c.Id);
        }
    }
}
