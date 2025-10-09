using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Users.Commands.DeleteUser;
using Tasks.Tests.Common.Moq;

namespace Tasks.Tests.Application.User.Command.DeleteUser
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<ITasksDbContext> _mockDbContext;
        private readonly DeleteUserCommandHandler _handler;
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        public DeleteUserCommandHandlerTests()
        {
            _mockDbContext = DbContextMockFactory.Create();
            _handler = new DeleteUserCommandHandler(_mockDbContext.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldRemoveUser_WhenUserExists()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new Tasks.Domain.User { Id = userId, Email = "test@example.com", PasswordHash = "hashed" };

            _mockDbContext.Setup(c => c.Users.FindAsync(new object[] { userId }, _cancellationToken))
                          .ReturnsAsync(user);

            // Act
            await _handler.Handle(new DeleteUserCommand { Id = userId }, _cancellationToken);

            // Assert
            _mockDbContext.Verify(c => c.Users.Remove(user), Times.Once);
            _mockDbContext.Verify(c => c.SaveChangesAsync(_cancellationToken), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldThrowNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = Guid.NewGuid();
            _mockDbContext.Setup(c => c.Users.FindAsync(It.IsAny<object[]>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((object[] ids, CancellationToken _) => null!);

            _mockDbContext.Setup(c => c.Users.FindAsync(new object[] { userId }, _cancellationToken))
                          .ReturnsAsync((Tasks.Domain.User)null!);

            // Act
            Func<System.Threading.Tasks.Task> act = async () => await _handler.Handle(new DeleteUserCommand { Id = userId }, _cancellationToken);

            // Assert
            await act.Should().ThrowAsync<NotFoundException>()
                     .WithMessage($"*{userId}*"); // Проверяем, что Id фигурирует в сообщении
        }
    }
}
