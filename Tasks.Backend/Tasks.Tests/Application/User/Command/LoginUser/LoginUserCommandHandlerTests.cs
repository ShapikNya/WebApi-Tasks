using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Users.Commands.LogingUsrt;
using Tasks.Application.Users.Commands.LoginUser;
using Tasks.Security;
using Tasks.Tests.Common.Base;
using Tasks.Tests.Common.Moq;

namespace Tasks.Tests.Application.User.Command.LoginUser
{
    /*public class LoginUserCommandHandlerTests : TestBase
    {
        private readonly Mock<ITasksDbContext> _mockDbContext;
        private readonly Mock<IJwtTokenService> _mockJwtService;
        private readonly LoginUserCommandHandler _handler;

        public LoginUserCommandHandlerTests()
        {
            _mockDbContext = DbContextMockFactory.Create();
            _mockJwtService = new Mock<IJwtTokenService>();
            _handler = new LoginUserCommandHandler(_mockDbContext.Object, _mockJwtService.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldThrowNotFoundException_WhenUserDoesNotExist()
        {
            // Arrange
            var command = new LoginUserCommand { Email = "notfound@example.com", Password = "Password123!" };

            _mockDbContext.Setup(c => c.Users.SingleOrDefaultAsync(
                It.IsAny<Expression<Func<Tasks.Domain.User, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync((Tasks.Domain.User)null!);

            // Act
            Func<System.Threading.Tasks.Task> act = async () => await _handler.Handle(command, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<NotFoundException>()
                     .WithMessage("*notfound@example.com*");
        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldThrowInvalidPasswordException_WhenPasswordIsIncorrect()
        {
            // Arrange
            var user = new Tasks.Domain.User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("CorrectPassword"),
                Role = "User"
            };

            _mockDbContext.Setup(c => c.Users.FirstOrDefaultAsync(
                 It.IsAny<Expression<Func<Tasks.Domain.User, bool>>>(),
                 It.IsAny<CancellationToken>()
             )).ReturnsAsync(user);

            var command = new LoginUserCommand { Email = "user@example.com", Password = "WrongPassword" };

            // Act
            Func<System.Threading.Tasks.Task> act = async () => await _handler.Handle(command, CancellationToken);

            // Assert
            await act.Should().ThrowAsync<InvalidPasswordException>();

        }

        [Fact]
        public async System.Threading.Tasks.Task Handle_ShouldReturnToken_WhenCredentialsAreValid()
        {
            // Arrange
            var user = new Tasks.Domain.User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Password123!"),
                Role = "User"
            };
            _mockDbContext.Setup(c => c.Users.FirstOrDefaultAsync(
                It.IsAny<Expression<Func<Tasks.Domain.User, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(user);

            _mockJwtService.Setup(j => j.GenerateToken(user.Id, user.Email, user.Role))
                .Returns("MockedToken");

            var command = new LoginUserCommand { Email = "user@example.com", Password = "Password123!" };

            // Act
            var token = await _handler.Handle(command, CancellationToken);

            // Assert
            token.Should().Be("MockedToken");
            _mockJwtService.Verify(j => j.GenerateToken(user.Id, user.Email, user.Role), Times.Once);
        }
    }*/
}
