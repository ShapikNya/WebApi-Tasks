using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Exceptions;
using Tasks.Application.Tasks.Commands.CreateTask;

namespace Tasks.Application.Tasks.Commands.UpdateNote
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly ITasksDbContext _dbContext;

        public UpdateTaskCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks.FindAsync(new object[] { request.Id }, cancellationToken);
            if (task == null) throw new NotFoundException(nameof(Domain.Task), request.Id);
            task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted; 
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
