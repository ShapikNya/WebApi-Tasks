using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITasksDbContext _dbContext;

        public CreateTaskCommandHandler(ITasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommand request,   
            CancellationToken cancellationToken)
        {
            var task = new Domain.Task
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                CreatedAt = DateTime.Now
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}
