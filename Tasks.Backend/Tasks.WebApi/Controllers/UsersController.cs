using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Application.Tasks.Commands.DeleteTask;
using Tasks.Application.Users.Commands.CreateUser;
using Tasks.Application.Users.Commands.DeleteUser;
using Tasks.Application.Users.Commands.LogingUsrt;
using Tasks.WebApi.Models.Users;
using Tasks.WepApi.Controllers;

namespace Tasks.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        public UsersController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Creates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /users
        /// {
        ///     "Email": "test@test.com",
        ///     "Password": "qwerty123"
        /// }
        /// </remarks>
        /// <param name="createUserDto">CreateUserDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
        {
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var UserId = await Mediator.Send(command);
            return Ok(UserId);
        }

        /// <summary>
        /// Deletes the user by id. Requires Admin role
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /users/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the user (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminOnly")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Logs in the user and returns a JWT token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /users/login
        /// {
        ///     "email": "first_user@test.com",
        ///     "password": "Qwwerty124"
        /// }
        /// </remarks>
        /// <param name="command">LoginUserCommand containing email and password</param>
        /// <returns>Returns JWT token</returns>
        /// <response code="200">Success, returns JWT token</response>
        /// <response code="400">Invalid request</response>
        /// <response code="401">Unauthorized, invalid credentials</response>
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand command)
        {
            var token = await Mediator.Send(command);
            return Ok(token);
        }
    }
}
