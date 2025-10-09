using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Tasks.Commands.CreateTask;

namespace Tasks.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITasksDbContext _dbContext;

        public DeleteTaskCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null || task.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(task), request.Id);
            }
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
