using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryValidator : AbstractValidator<GetTaskListQuery>
    {
        public GetTaskListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
