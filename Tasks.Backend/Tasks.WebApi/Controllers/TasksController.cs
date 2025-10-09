using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Application.Tasks.Commands.DeleteTask;
using Tasks.Application.Tasks.Commands.UpdateNote;
using Tasks.Application.Tasks.Queries.GetTaskDetails;
using Tasks.Application.Tasks.Queries.GetTaskList;
using Tasks.WebApi.Models.Tasks;

namespace Tasks.WepApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/tasks")]
    public class TasksController : BaseController
    {
        private readonly IMapper _mapper;
        public TasksController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of tasks. Requires Admin role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /tasks
        /// </remarks>
        /// <returns>Returns TaskListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskListVm>> GetAll()
        {
            var query = new GetTaskListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the task by id. Requires authorized users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /tasks/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">task id (guid)</param>
        /// <returns>Returns TaskDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TaskDetailsVm>> Get(Guid id)
        {
            var query = new GetTaskDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the task. Requires authorized users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /tasks
        /// {
        ///     "title": "HomeWork,
        ///     "description": "Math ex. 121(b)"
        /// }
        /// </remarks>
        /// <param name="createTaskDto">CreateTaskDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [Authorize(Policy = "UserOrAdmin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            command.UserId = UserId;
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }
        /// <summary>
        /// Updates the task. Requires authorized users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /task
        /// {
        ///     "id": "D34D349E-43B8-429E-BCA4-793C932FD580",
        ///     "title": "Cleaning room",
        ///     "description": "",
        ///     "isCompleted": true
        /// }
        /// </remarks>
        /// <param name="updateTaskDto">UpdateTaskDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [Authorize(Policy = "UserOrAdmin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            command.UserId = UserId;
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }


        /// <summary>
        /// Deletes the task by id. Requires authorized users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /task/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the task (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
