using Application.Common.Models;
using Application.UseCase.UserOperation.Commands.Create;
using Application.UseCase.UserOperation.Commands.Update;
using Application.UseCase.UserOperation.Queries;
using Domain.ValueObjects;
using Infrastructure.Presenters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialDev.Models;

namespace SocialDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersParameter parameters)
        {
            return this.Result(await _mediator.Send(new GetPaginatedUsers
            {
               PageNumber = parameters.PageNumber,
               PageSize = parameters.PageSize
            }));
        }

        [HttpPut("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(UpdateUserVm body)
        {
            return this.Result(await _mediator.Send(new UpdateUserCommand
            {
                Id = body.Id,
                FirstName = body.FirstName,
                LastName = body.LastName,
                Password = body.Password,
                Birthday = body.Birthday,
                Gender = body.Gender
            }));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserById(string id) => this.Result(await _mediator.Send(new GetUserByIdQuery { Id = id }));

        //[HttpPost("")]
        //[ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
        //[ProducesResponseType(typeof(Notify), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CreateUser(CreateUserCommand body) => this.Result(await _mediator.Send(body));
    }
}
