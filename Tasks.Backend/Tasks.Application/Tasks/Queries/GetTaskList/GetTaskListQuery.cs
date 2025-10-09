using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Queries.GetTaskDetails;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListVm>
    {
         public Guid UserId { get; set; }
    }
}
