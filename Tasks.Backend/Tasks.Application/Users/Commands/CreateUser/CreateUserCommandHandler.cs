using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Security;

namespace Tasks.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IJwtTokenService _jwtService;

        public CreateUserCommandHandler(ITasksDbContext dbContext, IJwtTokenService jwtService)
        {
            _dbContext = dbContext; _jwtService = jwtService;
        }

        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var user = new Domain.User
            {
                Id = id,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }

    }
}
