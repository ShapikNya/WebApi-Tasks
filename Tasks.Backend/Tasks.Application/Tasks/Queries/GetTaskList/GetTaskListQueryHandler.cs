using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Queries.GetTaskDetails;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITasksDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVm> Handle(GetTaskListQuery request,
           CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.Tasks
                /*.Where(t => t.UserId == request.UserId)*/
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { Tasks = tasks };
        }

    }
}
