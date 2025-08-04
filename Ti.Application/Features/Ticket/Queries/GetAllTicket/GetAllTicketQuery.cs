using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti.Application.Features.Ticket.Queries.GetAllTicket
{
    public class GetAllTicketQuery : IRequest<List<GetAllTicketDto>>
    {
    }
}
