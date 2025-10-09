using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Tasks.Commands.DeleteTask;
using Tasks.Application.Users.Commands.CreateUser;

namespace Tasks.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly ITasksDbContext _dbContext;
        public DeleteUserCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(DeleteUserCommand request,
           CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
