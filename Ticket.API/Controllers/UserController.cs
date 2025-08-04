using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ti.Application.Features.User.Commands.CreateUser;

namespace Ticket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> User(CreateUserCommand createUser)
        {
            var result = await _mediator.Send(createUser);    
            return Ok(result);
        }
    }
}