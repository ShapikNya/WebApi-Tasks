using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class TaskListVm
    {
        public IList<TaskLookupDto> Tasks { get; set; }
    }
}
