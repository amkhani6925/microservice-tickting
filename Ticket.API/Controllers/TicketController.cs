using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ti.Application.Features.Ticket.Commands.CreateTicket;
using Ti.Application.Features.Ticket.Commands.UpdateStatus;
using Ti.Application.Features.Ticket.Queries.GetAllTicket;
using Ti.Application.Features.Ticket.Queries.GetTicketByUser;
using Ti.Application.Features.Ticket.Queries.GetTicketCountByStatus;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Ticket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateTicket")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Ticket(CreateTicketCommand createTicket)
        {
            var result = await _mediator.Send(createTicket);    
            return Ok(result);
        }
        [HttpGet("My")] 
        [Authorize(Roles = "Employee")]  
        public async Task<IActionResult> GetUserTickets(GetTicketByUserIdQuery query)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var getQuery = new GetTicketByUserIdQuery { UserId = Guid.Parse(userId) };
            var result = await _mediator.Send(getQuery);
            return Ok(result);
        }
        [HttpGet("GetAllTickets")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTicketQuery());
            return Ok(result);
        }
        [HttpPut("AssignTicket")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(UpdateStatusAndAssignCommand command, Guid id)
        {
            command.TicketId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("TicketCountByStatus")]        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Stats(GetTicketsCountByStatusQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
