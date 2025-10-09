using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Users.Commands.DeleteUser;
using Tasks.Application.Users.Commands.LogingUsrt;
using Tasks.Security;

namespace Tasks.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IJwtTokenService _jwtService;
        public LoginUserCommandHandler(ITasksDbContext dbContext, IJwtTokenService jwtService)
        {
            _dbContext = dbContext; _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
         .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(user), request.Email);

            bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!validPassword)
                throw new InvalidPasswordException(nameof(user), request.Password);

            var token = _jwtService.GenerateToken(user.Id, user.Email, user.Role);
            return token;
        }
    }
}
