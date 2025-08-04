using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ti.Domain.Enums;

namespace Ti.Application.Features.Ticket.Queries.GetTicketCountByStatus
{
    public class GetTicketsCountByStatusQuery : IRequest<int>
    {
        public TicketStatus Status { get; set; }
    }
}
