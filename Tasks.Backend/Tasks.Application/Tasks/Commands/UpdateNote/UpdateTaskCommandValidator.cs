using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Tasks.Commands.DeleteTask;

namespace Tasks.Application.Tasks.Commands.UpdateNote
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(deleteNoteCommand => deleteNoteCommand.Id).NotEqual(Guid.Empty);
            /*RuleFor(deleteNoteCommand => deleteNoteCommand.UserId).NotEqual(Guid.Empty);*/
            RuleFor(createTaskCommand =>
                createTaskCommand.Title).NotEmpty().MaximumLength(32);
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).MaximumLength(250);
        }
    }
}
