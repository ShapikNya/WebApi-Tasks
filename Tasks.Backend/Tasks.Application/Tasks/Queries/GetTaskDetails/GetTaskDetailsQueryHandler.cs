using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application;
using Tasks.Application.Common.Exceptions;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler : IRequestHandler<GetTaskDetailsQuery, TaskDetailsVm>
    {
        private readonly ITasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITasksDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        { 
            var task = await _dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (task == null) { throw new NotFoundException(nameof(task), request.Id); }

            return _mapper.Map<TaskDetailsVm>(task);
        }
    }
}
