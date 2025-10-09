using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.Title).NotEmpty().MaximumLength(32);
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).MaximumLength(250);
            /*RuleFor(createTaskCommand =>
                createTaskCommand.UserId).NotEqual(Guid.Empty);*/
        }
    }
}
