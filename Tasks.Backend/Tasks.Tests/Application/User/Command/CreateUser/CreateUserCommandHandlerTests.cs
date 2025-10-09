using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Application.Users.Commands.CreateUser;
using Tasks.Tests.Common.Base;
using Tasks.Tests.Common.Moq;

namespace Tasks.Tests.Application.User.Command.CreateUser
{
    public class CreateUserCommandHandlerTests : TestBase
    {
        private readonly Mock<ITasksDbContext> _mockDbContext;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _mockDbContext = DbContextMockFactory.Create();
            _handler = new CreateUserCommandHandler(_mockDbContext.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldCreateUser_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Email = "test@example.com",
                Password = "Password123!"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken);

            // Assert
            result.Should().NotBeEmpty();
            _mockDbContext.Verify(c => c.Users.AddAsync(It.IsAny<Tasks.Domain.User>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockDbContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldHashPassword_WhenUserIsCreated()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Email = "user@example.com",
                Password = "Password123!"
            };

            Tasks.Domain.User addedUser = null!;
            _mockDbContext.Setup(c => c.Users.AddAsync(It.IsAny<Tasks.Domain.User>(), It.IsAny<CancellationToken>()))
                          .Callback<Tasks.Domain.User, CancellationToken>((u, ct) => addedUser = u)
                          .ReturnsAsync((Tasks.Domain.User u, CancellationToken ct) => null!);

            // Act
            await _handler.Handle(command, CancellationToken);

            // Assert
            addedUser.Should().NotBeNull();
            addedUser.PasswordHash.Should().NotBe(command.Password);
            BCrypt.Net.BCrypt.Verify(command.Password, addedUser.PasswordHash).Should().BeTrue();
        }
    }
}
