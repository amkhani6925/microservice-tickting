using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti.Application.Features.Ticket.Queries.GetTicketByUser
{
    public class GetTicketByUserIdQuery : IRequest<List<GetTicketByUserDto>>
    {
        public Guid UserId { get; set; }
    }
}
