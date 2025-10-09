using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
